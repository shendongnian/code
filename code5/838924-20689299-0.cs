    [Test]
    public void TestCase1() 
    {
        driver.Navigate().GoToUrl(baseUrl);
        driver.FindElement(By.Name("q")).SendKeys("WhatIsMyIP");
        driver.FindElement(By.Name("btnG")).Click();
    }
