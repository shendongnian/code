    //Displayed
    public static bool IsElementDisplayed(this IWebDriver driver, By element)
    {
        if (driver.FindElements(element).Count > 0)
        {
            if (driver.FindElement(element).Displayed)
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }
    //Enabled
    public static bool IsElementEnabled(this IWebDriver driver, By element)
    {
        if (driver.FindElements(element).Count > 0)
        {
            if (driver.FindElement(element).Enabled)
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }
