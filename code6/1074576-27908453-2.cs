    By byXpath = By.XPath("//select[@id='DocumentType']");
    
    //wait for the element to exist
    new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(byXpath));
    
    IWebElement element = Driver.FindElement(byXpath);
    var selectElement = new SelectElement(element);
    int options = selectElement.Options.Count;
    
    for (int i = 0; i < options; i++)
    {
        Console.WriteLine(selectElement.Options[i].Text);
        
        //in case if other options refreshes the DOM and throws StaleElement reference exception
        new SelectElement(Driver.FindElement(byXpath)).SelectByIndex(i);
    
        //do the rest of the stuff
    }
