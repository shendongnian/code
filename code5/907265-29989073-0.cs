    public void WaitForElementNotVisible(string id, int seconds)
        {
                     
            try
            {
                var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(seconds));                   
                wait.Until(driver1 => !visibility(id));
                Console.WriteLine("Element is not visible..");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Element is still visible..");
            }
        }
        bool visibility(string id)
        {
            bool flag;
            try
            {
                flag = driver.FindElement(FindWebElements(locator)).Displayed;
            }
            catch (NoSuchElementException)
            {
                flag = false;
            }
            return flag;
        }
