    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Interactions;
    IWebDriver driver = new FirefoxDriver(ffprofile);
    driver.Navigate().GoToUrl("http://www.google.com");
    driver.FindElement(By.Name("q")).SendKeys("Stack Overflow");
    driver.FindElement(By.Name("q")).Submit();
    Actions action = new Actions(driver);
    action.SendKeys(OpenQA.Selenium.Keys.Escape);
