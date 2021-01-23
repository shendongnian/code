    public void Wait(Func<IWebDriver, bool> condition, double delay)
    {
    	var ignoredExceptions = new List<Type>() { typeof(StaleElementReferenceException) };
    	var wait = new WebDriverWait(myWebDriver, TimeSpan.FromMilliseconds(delay)));
    	wait.IgnoreExceptionTypes(ignoredExceptions.ToArray());
    	wait.Until(condition);
    }
    public void SelectionIsDoneDisplayingThings()
    {
        Wait(driver => driver.FindElements(By.ClassName("selection")).All(x => x.Displayed), 250);
    }
