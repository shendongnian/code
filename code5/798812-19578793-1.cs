    public static IWebElement WaitGetElement(this IWebDriver driver, By by, int timeoutInSeconds, bool checkIsVisible=false)
    {
	IWebElement element;
	var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
	try
	{
		if (checkIsVisible)
		{
			element = wait.Until(ExpectedConditions.ElementIsVisible(by));
		}
		else
		{
			element = wait.Until(ExpectedConditions.ElementExists(by));
		}
	}
	catch (NoSuchElementException) { element = null; }
	catch (WebDriverTimeoutException) { element = null; }
	catch (TimeoutException) { element = null; }
	
	return element;
    }
