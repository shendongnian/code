    [TestClass]
    public class LoginPage
    {
        public WebDriver web1;
        public IDisposable loginSubmitBtn;
        public LoginPage()
        {
            web1 = new WebDriver();
            loginSubmitBtn = web1.Driver.FindElement(By.XPath(""));
        }
    }
