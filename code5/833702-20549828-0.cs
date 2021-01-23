        public static void WaitForElementNotPresent(this ISearchContext driver, By locator)
        {
            driver.TimerLoop(() => driver.FindElement(locator).Displayed, true, "Timeout: Element did not go away at: " + locator);
        }
        
        public static void WaitForElementToAppear(this ISearchContext driver, By locator)
        {
            driver.TimerLoop(() => driver.FindElement(locator).Displayed, false, "Timeout: Element not visible at: " + locator);
        }
        public static void TimerLoop(this ISearchContext driver, Func<bool> isComplete, bool exceptionCompleteResult, string timeoutMsg)
        {
            const int timeoutinteger = 10;
            for (int second = 0; ; second++)
            {
                try
                {
                    if (isComplete())
                        return;
                    if (second >= timeoutinteger)
                        throw new TimeoutException(timeoutMsg);
                }
                catch (Exception ex)
                {
                    if (exceptionCompleteResult)
                        return;
                    if (second >= timeoutinteger)
                        throw new TimeoutException(timeoutMsg, ex);
                }
                Thread.Sleep(100);
            }
        }
