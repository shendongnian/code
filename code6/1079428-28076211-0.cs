    public bool CheckElementExist(string state)
    {
        By byCss = By.CssSelector("#view-" + state + "");
        try
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(byCss));
    		return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
