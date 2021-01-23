    public void Test(string filepath)
    {
        By byCss = By.CssSelector("your selector");
        //explicit wait to make sure the element is visible
        new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(byCss));
        Driver.FindElement(byCss).SendKeys(filepath);
    }
