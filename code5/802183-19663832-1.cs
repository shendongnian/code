	private class SoftVerifier
	{
		private StringBuilder verificationErrors;
		public SoftVerifier()
		{
			verificationErrors = new StringBuilder();
		}
		public void VerifyElementIsPresent(IWebElement element)
		{
			if (!element.Displayed)
			{
				verificationErrors.Append("Element was not displayed");
			}
		}
	}
