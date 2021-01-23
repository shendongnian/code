    // Assume that the element you click on to add a new element
    // is stored in the variable 'element', and your IWebDriver
    // variable is 'driver'.
    int originalCount = clientPage.ListObjectElements.Count;
    element.Click();
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    wait.Until<bool>(
    {
        return clientPage.ListObjectElements.Count > originalCount;
    });
    return clientPage.ListObjectElements;
    
