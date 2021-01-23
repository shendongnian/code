    [TestClass]
    public class LoginPage
    {
       public WebDriver web1 = new WebDriver();
       public IWebElement loginSubmitBtn;
       public LoginPage() 
       {
            loginSubmitBtn = web1.Driver.FindElement(By.XPath(""));
       }
    }
