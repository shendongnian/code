    [FindsBy(How = How.TagName, Using = "a")]
    public static IList<IWebElement> LinkElements { get; set; }
    
    
    private void LoopLink()
    {
        int count = LinkElements.Count;
    
        for (int i = 0; i < count; i++)
        {
            Driver.FindElements(By.TagName("a"))[i].Click();
            //some ways to come back to the previous page
        }
    
    }
