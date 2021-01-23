	public static IWebElement WaitForElement(IWebDriver driver, By selector)
	{    
		WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10);
		return wait.Until<IWebElement>(d =>
		{
				try
				{
					return d.FindElement(selector);
				}
				catch
				{
					return null;
				}
		});
	}
