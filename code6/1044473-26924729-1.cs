    using (IWebDriver driver = new ChromeDriver())
                {
    
                    driver.Navigate().GoToUrl("http://sinhvienit.net/forum/");
    
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30)); //Give the implicit wait time
                   
                   driver.FindElement(By.XPath("//button[@id='btnSubmit1']")).Click();// Clicking on the button present in prior page of forum
                    
                  //Waiting till the element that marks the page is loaded properly, is visible
                  var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));  
            
                  wait.Until(ExpectedConditions.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='vtlai_topx']/a")));
    
                   driver.FindElement(By.XPath("//a[@href='#loginform']")).Click();
                    
