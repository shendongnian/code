    [TestMethod]
    public void TestMethod1()
    {
      By byXpath = By.XPath("//android.widget.Button[@text='Get Started']");
      IWebElement webElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d=>d.FindElement(byXpath));
      webElement.Click();
    }
