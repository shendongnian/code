    for (int i = 3; i < count; i++) {
        IWebElement e = PropertiesCollection.driver.FindElements(By.TagName("a"))[i];
        if (e != null && e.Displayed) {
            e.Click();
        }
    }
