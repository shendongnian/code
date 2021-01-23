    using GenericLib;
    namespace PageFactory
    {
    
        [TestClass]
        public class LoginPage
        {
           public WebDriver web1;
           public IWebElement loginSubmitBtn;
    
           [TestInitialize]
           public void TestSetup()
           {
              web1 = new WebDriver();
              loginSubmitBtn = web1.Driver.FindElement(By.XPath(""));
           } 
         }
    }
