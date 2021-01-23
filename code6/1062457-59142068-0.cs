        ElementExists(By.Id(id));
        static public bool ElementExists(By method)
        {
            var oldTime = _driver.Manage().Timeouts().ImplicitWait;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1);
            try
            {
                bool isElementDisplayed = _driver.FindElement(method).Displayed;
                _driver.Manage().Timeouts().ImplicitWait = oldTime;
                return true;
            }
            catch
            {
                _driver.Manage().Timeouts().ImplicitWait = oldTime;
                return false;
            }
        }
