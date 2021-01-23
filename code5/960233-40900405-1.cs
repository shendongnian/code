            var options = new PhantomJSOptions();
            options.AddAdditionalCapability("IsJavaScriptEnabled", true);
            IWebDriver driver = new PhantomJSDriver("phantomjs Folder Path", options);
            driver.Navigate().GoToUrl("https://www.yourwebsite.com/");
            try
            {
                string pagesource = driver.PageSource;
                driver.FindElement(By.Id("yourelement"));
                Console.Write("yourelement founded");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            Console.Read();
