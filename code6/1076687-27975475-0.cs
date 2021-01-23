    public void Test()
    {
        By @by = By.XPath("//span[contains(@class,'smtListName')][contains(text(),'lastname')]");
        
        try
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(@by));
        }
        catch (NoSuchElementException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
