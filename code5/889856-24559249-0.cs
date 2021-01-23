    IWebElement option = driver.FindElement(By.Id("labelPosittion-step-1"));
    //List<IWebElement> Links = new List<IWebElement>(option.FindElements(By.XPath(".//tbody/tr/td")));
    List<IWebElement> Links = new List<IWebElement>(driver.FindElements(By.ID("labelPosittion-step-1")));    
                
    for (int k = 0; k < Links.Count; k++)
    {
        if (Links[k].Text == "inside")
        {
        option = Links[k];
        }
    }
    option.Click();
