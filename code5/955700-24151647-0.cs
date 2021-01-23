	public static IWebElement WaitForAndFindElement(this IWebDriver driver, By by)
	{
		// do a wait
		// something like...
		WebDriverWait wait = new WebDriverWait(TimeSpan.FromSeconds(60)); // hard code it here if you want to avoid each calling method passing in a value
		
		return wait.Until(webDriver => 
			{
				if (webDriver.FindElement(by).Displayed)
				{
					return webDriver.FindElement(by);
				}
				return null; // returning null with force the wait class to iterate around again.
			});
	}
