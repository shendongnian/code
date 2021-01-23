	public void Click(string cssSelector)
	{
		Log("Clicking element \"{0}\".", cssSelector.Replace("\"", "\\\""));
		IWebElement webElement = (IWebElement)_driver.ExecuteScript("return $('" + cssSelector + "');");
		webElement.Click();
	}
