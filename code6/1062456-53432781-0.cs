    protected Func<IWebElement> GetLazyElement(By by, int retryCount=0)
            {
                if (retryCount >= ELEMENT_FIND_WAIT_RETRY_COUNT)
                {
                    throw new Exception("Wait timeout for element to show up" + by.ToString());
                }
                return new Func<IWebElement>(() => {
                    try
                    {
                        Debug.WriteLine("Finding element " + by.ToString());
                        var element = _webDriver.FindElement(by);
    
                        return element;
                    }
                    catch (Exception)
                    {
                        Debug.WriteLine($"Failed to find element: {by} (Waiting {ELEMENT_FIND_WAIT_TIME}ms)");
                        Thread.Sleep(ELEMENT_FIND_WAIT_TIME);
                        var lazyFunc = GetLazyElement(by, retryCount++);
                        return lazyFunc();
                        
                    }
                    
                });
    }
