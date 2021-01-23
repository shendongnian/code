       IWebDriver WebDriver = null;
   
    public static void InitializeDriver(TestContext t)
        {
          if (WebDriver == null)
                {
                                      
                    string DRIVER_PATH = @"C:\automation\driversFolder\";
                    switch (Browser.Type)
                    {
                        case "IE":
                          
                            WebDriver = new InternetExplorerDriver(DRIVER_PATH);                         
                           
                            break;
                        case "FF": 
                            WebDriver = new FirefoxDriver();
                            break;
                        case "CR":
                                                      
                            WebDriver = new ChromeDriver(DRIVER_PATH);
                            break;
                        default:
                            WebDriver = new FirefoxDriver();                           
                            break;
                    }
                }
            
        }
