    public static bool ElementExists(this IWebDriver driver, By condition, TimeSpan? timeSpan)
    {
        bool isElementPresent = false;
        if (timeSpan == null)
        {
            timeSpan = TimeSpan.FromMilliseconds(15000);
        }
        var driverWait = new WebDriverWait(driver, (TimeSpan)timeSpan);
        driverWait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
        isElementPresent = driverWait.Until(x => x.FindElements(condition).Any());
        return isElementPresent;
    }
