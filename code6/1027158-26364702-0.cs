	public void Click(string cssSelector)
	{
		Log("Clicking element \"{0}\".", cssSelector.Replace("\"", "\\\""));
		_driver.FindElementByCssSelector(cssSelector).Click();
	}
