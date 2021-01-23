    public static IWebElement WaitForElementToAppear(IWebDriver driver, int waitTime, By waitingElement)
	{
			IWebElement wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementExists(waitingElement));
			return wait;
	}
