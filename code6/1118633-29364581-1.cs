    var e = PropertiesCollection.driver.FindElements(By.TagName("a"));
    for (int i = 3; i < e.Count; i++) {
        if (e[i].Displayed) {
            e[i].Click();
        }
    }
