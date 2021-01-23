    public static void ClickWithIeHackFailover(this IWebElement element)
    {
        try
        {
            element.Click();
        }
        catch (WebDriverException e)
        {
            if (e.Message != "Timed out waiting for page to load.")
            {
                element.SendKeys("\n");
            }
        }
    }
