        /// <summary>
        /// WaitForElementOnPage() method waits a passed number of seconds for the existence
        /// of a passed IWebElement object. If the object is found the method return an IWebElement of the object
        /// If the object is not found in the passed number of seconds, the method returns a null IWebElement
        /// </summary>
     
        public IWebElement WaitForElementOnPage(string controlID, int waitTime)
        {
            IWebElement element = null;
            IWebElement elementFound = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTime));
                Thread.Sleep(3000);
                elementFound = wait.Until<IWebElement>((d) =>
                {
                            element = d.FindElement(By.Id(controlID));
                            break;
                    
                    return element;
                });
            }
            catch (Exception ex)
            {                        
                Log.Error(ex);
                elementFound = null;
            }
            return elementFound ;
        }
