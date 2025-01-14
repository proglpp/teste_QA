using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

class TesteAutomatizado
{
    static void Main(string[] args)
    {
        // Configuração do WebDriver
        IWebDriver driver = new ChromeDriver();
        try
        {
            // Acessar a página inicial da aplicação
            driver.Navigate().GoToUrl("https://planoaliados.com.br/portal/");
            driver.Manage().Window.Maximize();

            // Localizar o campo Usuário e inserir o valor
            IWebElement campoUsuario = driver.FindElement(By.Name("usuario"));
            campoUsuario.SendKeys("057.484.723-50");

            // Localizar o campo Senha e inserir o valor
            IWebElement campoSenha = driver.FindElement(By.Name("senha"));
            campoSenha.SendKeys("654321");

            // Localizar e clicar no botão Entrar
            IWebElement botaoEntrar = driver.FindElement(By.Name("entrar"));
            botaoEntrar.Click();

            // Verificar se a mensagem de sucesso é exibida
            System.Threading.Thread.Sleep(2000); // Tempo para carregar a resposta (ajustar conforme necessário)
            IWebElement mensagemSucesso = driver.FindElement(By.XPath("//*[contains(text(),'Login realizado com sucesso!')]"));

            if (mensagemSucesso.Displayed)
            {
                Console.WriteLine("Teste bem-sucedido: Mensagem de sucesso exibida.");
            }
            else
            {
                Console.WriteLine("Teste falhou: Mensagem de sucesso não exibida.");
            }
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Teste falhou: Elemento não encontrado. {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
        finally
        {
            // Fechar o navegador
            driver.Quit();
        }
    }
}
