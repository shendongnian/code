    public bool SummaryDisplayed()
    {
        try
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var myElement = wait.Until(x => x.FindElement(By.Id("summaryPage")));
            return  myElement.Displayed;
        }
        catch
        {
            return false;
        }
    }
