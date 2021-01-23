	namespace Something.Something.Helpers
	{
		public static class Utilities
		{
			public static ActionResult TryNavigateToTab(this ITabNavigation self,
												 string tabId,
												 string tabLoadedElementId)
			{
			    try
			    {
			        //Driver is a static singelton
			        Driver.FindElement(tabId).Click();
			        Driver.WaitUntilPresent(tabLoadedElementId);
                                // TODO: return something
			    }
			    catch (Exception ex)
			    {
			        return new FailureActionResult(ex.Message);
			    }
			}
		}
	}
