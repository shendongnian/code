    using SeleniumExtensions;
    // ...
    IWebElement element = null;
    if (driver.TryFindElement(By.Id("item-01"), out element)
    {
        // use element
    }
    else
    {
         // element is null
    }
