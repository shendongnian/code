	private class SoftVerifier
	{
		private StringBuilder verificationErrors;
		public SoftVerifier()
		{
			verificationErrors = new StringBuilder();
		}
		public void VerifyElementIsPresent(IWebElement element)
		{
			try
			{
				Assert.IsTrue(element.Displayed);
			}
			catch (AssertionException)
			{
				verificationErrors.Append("Element was not displayed");
			}
		}
	}
