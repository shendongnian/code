    //Displayed
    public static bool IsElementDisplayed(this IWebDriver driver, By element)
    {
        IReadOnlyCollection<IWebElement> elements = driver.FindElements(element);
        if (elements.Count > 0)
        {
            return elements.ElementAt(0).Displayed;
        }
        return false;
    }
    //Enabled
    public static bool IsElementEnabled(this IWebDriver driver, By element)
    {
        IReadOnlyCollection<IWebElement> elements = driver.FindElements(element);
        if (elements.Count > 0)
        {
            return elements.ElementAt(0).Enabled;
        }
        return false;
    }
