     try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(ExpectedConditions.ElementIsVisible(by));
                }
                return driver.FindElement(by);
            }
            catch(Exception e)
            {
                throw;
            }
