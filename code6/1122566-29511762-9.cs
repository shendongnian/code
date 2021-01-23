    public static IWebElement FindElementAfterWait(this IWebDriver driver, By condition)
    {
        bool isElementPresent = false;
        IWebElement singleElement = null;
        var driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
        driverWait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
        isElementPresent = driverWait.Until(x => x.FindElement(condition) != null);
        if (isElementPresent)
        {
            singleElement = driver.FindElement(condition);
        }
        return singleElement;
    }
