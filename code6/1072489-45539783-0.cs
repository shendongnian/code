    static void Main(string[] args)
            {
                APILauncher launch = new APILauncher(true);
    
                Pattern image1 = new Pattern(@"C:\Users\Ramesh\Desktop\Images\userName.png");
                Pattern image2 = new Pattern(@"C:\Users\Ramesh\Desktop\Images\password.png");
                Pattern image3 = new Pattern(@"C:\Users\Ramesh\Desktop\Images\Login.png");
    
                launch.Start();
    
                IWebDriver driver = new ChromeDriver();
    
                driver.Manage().Window.Maximize();
    
                driver.Url = "http://design-test11.cricut.com/#/sign-in";
    
                Screen scr = new Screen();
    
                scr.Type(image1, "cricut", KeyModifier.NONE);
    
                scr.Type(image2, "Cr1cut123", KeyModifier.NONE);
    
                scr.Click(image3, true);
    
                Console.ReadLine();
            }
