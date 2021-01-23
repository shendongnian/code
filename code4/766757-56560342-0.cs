    public static IWebDriver Driver { set; get; }
    -----
    Driver = CreateBrowserDriver();
    
    ////////////// Create Driver
    private static IWebDriver CreateBrowserDriver()
    {
    	try
    	{
    		var options = new OpenQA.Selenium.Chrome.ChromeOptions();
    		options.AddArguments("--disable-extensions");
    		options.AddArgument("--headless"); // HIDE Chrome Browser
    		var service = OpenQA.Selenium.Chrome.ChromeDriverService.CreateDefaultService();
    		service.HideCommandPromptWindow = true; // HIDE Chrome Driver
    		service.SuppressInitialDiagnosticInformation = true;
    
    		return new OpenQA.Selenium.Chrome.ChromeDriver(service, options);
    	}
    	catch
    	{
    		throw new Exception("Please install Google Chrome.");
    	}
    }
    ////////////// Exit Driver
    public static void ExitDriver()
    {
    	if (Driver != null)
    	{
    		Driver.Quit();
    	}
    
    	Driver = null;
    
    	try
    	{
    		// Chrome
    		System.Diagnostics.Process.GetProcessesByName("chromedriver").ToList().ForEach(px => px.Kill());
    	}
    	catch { }
    }
