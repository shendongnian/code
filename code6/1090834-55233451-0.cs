	public static IWebElement GetElementAndScrollTo(this IWebDriver driver, By by)
	{
		var js = (IJavaScriptExecutor)driver;
		try
		{
			var element = driver.FindElement(by);
			if (element.Location.Y > 200)
			{
				js.ExecuteScript($"window.scrollTo({0}, {element.Location.Y - 200 })");
			}
			return element;
		}
		catch (Exception ex)
		{
			return null;
		}
	}
