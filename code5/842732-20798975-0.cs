	public static void press(params string[] keys)
	{
		   foreach (string key in keys) 
		   { 
			  WebDriver.SwitchTo().ActiveElement().SendKeys(key);
			  Sleep(2000);
		   }
	}
