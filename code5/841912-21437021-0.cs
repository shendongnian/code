    foreach (string handle in browser.WindowHandles) 
            {
                IWebDriver popup = driver.SwitchTo().Window(handle);
                if (popup.Title.Contains("popup title")) 
                {
                  break;
                }
            }
    
    IWebElement closeButton = driver.FindElement(By.Id("closeButton"));
    closeButton.Click();
