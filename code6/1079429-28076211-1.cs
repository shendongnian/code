    public bool CheckElementExist(string state)
    {
        //Write the selector carefully.
        By byCss = By.CssSelector("#view-" + state + "");
        try
        {
         //Explicit wait to check if element exist for 10s   
         new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(byCss));
    		return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
