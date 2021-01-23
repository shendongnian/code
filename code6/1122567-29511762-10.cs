    public static IWebElement FindElementAfterWait(this IWebDriver driver, Func<IWebDriver, IWebElement> condition)
    {
        IWebElement singleElement = null;
        var driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
        driverWait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
        singleElement = driverWait.Until(condition);
        return singleElement;
    }
