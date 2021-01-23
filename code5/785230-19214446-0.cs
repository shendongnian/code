    public static IAlert WaitGetAlert(this IWebDriver driver, int waitTimeInSeconds = 5)
    {
    	IAlert alert = null;
    
    	WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
    
    	try 
    	{
    		alert = wait.Until(d =>
    			{
    				try
    				{
    					// Attempt to switch to an alert
    					return driver.SwitchTo().Alert();
    				}
    				catch (NoAlertPresentException)
    				{
    					// Alert not present yet
    					return null;
    				}
    			});
    	}
    	catch (WebDriverTimeoutException) { alert = null; }
    
    	return alert;
    }
