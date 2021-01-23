    [TestFixture]
    public class TestCase123
    {
        [Test]
        public void SendMessage()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.somesite.com/");
            IWebElement query = driver.FindElement(By.Name("username"));
            query.SendKeys("blablabla");
            driver.FindElement(By.Name("password")).SendKeys("blablabla");
            driver.FindElement(By.Id("btnLogin")).Submit();
            new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            driver.Navigate().GoToUrl("https://www.somesite.com/sendmessage/john");
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.LinkText("Message"))));
            driver.FindElement(By.LinkText("Message")).Click();
            driver.FindElement(By.LinkText("MessageText")).SendKeys(txtMessage.Text);
            Actions action = new Actions(driver);
            action.SendKeys(Keys.Enter);
            action.Perform();
        }
    }
