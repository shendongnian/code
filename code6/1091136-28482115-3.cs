     public class Driver<TWebDriver> where TWebDriver : IWebDriver, new()
     {
    
        public static IWebDriver Instance { get; set; }
    
        public static void Initialize()
        {
            if (typeof(TWebDriver) == typeof(ChromeDriver))
            {
    
                
             var browser = DesiredCapabilities.Chrome();
                    System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", "C:/Users/jm/Documents/Visual Studio 2013/Projects/VNextAutomation - Copy - Copy (3)/packages/WebDriverChromeDriver.2.10/tools/chromedriver.exe");
                    ChromeOptions options = new ChromeOptions() { BinaryLocation = "C:/Users/jm/AppData/Local/Google/Chrome/Application/chrome.exe" };
                    browser.SetCapability(ChromeOptions.Capability, options);
                    Console.Write("Testing in Browser: " + browser.BrowserName);
    
    
    
                    Instance = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), browser);
    
                } else {
                   Console.Write("Testing in Browser: "+ browser.BrowserName);
                   Instance = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), browser);
               }   
            }
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }
    }
