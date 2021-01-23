    By byXpath = By.XPath("//*[@id='watch-toolbar']/aside/div/span");
    IWebElement element =
        new WebDriverWait(_driver, TimeSpan.FromSeconds(90)).Until(ExpectedConditions.ElementExists(byXpath));
    
    
    if (element.Text.Trim() == "3")
    {
        //Pass this
    }
    
    //Another options with LINQ
    string watchprogress = new WebDriverWait(_driver, new TimeSpan(10)).Until(e => e.FindElement(byXpath)).Text.Trim();
    
    if (watchprogress == "3")
    {
        
    }
