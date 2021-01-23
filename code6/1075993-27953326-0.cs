    public void ClickThroughLinks()
    {
        Driver.Navigate().GoToUrl("http://www.cnn.com/");
        //Maximize the window so that the list can be gathered successfully.
        Driver.Manage().Window.Maximize();
    
        //find the list
        By xPath = By.XPath("//h2[.='The Latest']/../li//a");
        IReadOnlyCollection<IWebElement> linkCollection = Driver.FindElements(xPath);
        
        for (int i = 0; i < linkCollection.Count; i++)
        {
            //wait for the elements to be exist
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(xPath));
    
            //Click on the elements by index
            Driver.FindElements(xPath)[i].Click();
            Driver.Navigate().Back();
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
        }
    }
