    public class Login
    {
        /// <summary>
        /// Get or set driver
        /// </summary>
        public IWebDriver Driver { get; set; }
        
        public Login(IWebDriver driver)           
        {
            this.Driver = driver;
        }
        public static void LogIn(string Env, string User)
          {
            Driver.Navigate().GoToUrl(Env);
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(3000));
            Driver.FindElement(By.XPath("//*[@ng-model='email']")).SendKeys(User);
            Driver.FindElement(By.XPath("//*[@ng-model='password']")).SendKeys("1234");
            Driver.FindElement(By.XPath("//*[@id=\"ui-view\"]/div/div/div[1]/form/div[2]/button")).Click();
            System.Threading.Thread.Sleep(2000);
            NUnit.Framework.Assert.IsTrue(Driver.FindElement(By.Name("some element")).Displayed,
                "Login failed, home page did not display");
        }
    }
