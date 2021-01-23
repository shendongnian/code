    // you can use xpath or cssselector to identify the iframe
    driver.SwitchTo().Frame(driver.FindElement(By.Id("iframe id")));
    
    By css = By.CssSelector("#ctl00_mainContent_Tabs_TabPanelEmploymentAdmin_EmploymentAdmin_grvAssignmentHistory tr");
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    
    IList<IWebElement> elementCollectionHead = wait.Until(webDriver => webDriver.FindElements(css));
    int rowCount = elementCollectionHead.Count;
    
    driver.SwitchTo().DefaultContent();
