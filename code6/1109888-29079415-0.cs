    public class DriverFactory
    {
    	public IWebDriver Driver { get; set; }
    	
    	public enum DriverType
    	{
    		IE,
    		Firefox,
    		Chrome
    	}
    	
    	public IWebDriver GetDriver(DriverType typeOfDriver)
    	{
    		if (typeOfDriver == DriverType.IE) return new InternetExplorerDriver();
    		if (typeOfDriver == DriverType.Chrome) return new ChromeDriver();
    		return new FirefoxDriver(); // return firefox by default
    	}
    }
