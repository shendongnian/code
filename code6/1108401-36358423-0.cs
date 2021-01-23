    public static string ClickAndSwitchWindow(IWebElement elementToBeClicked,
    IWebDriver driver, int timer = 2000)
            {
                System.Collections.Generic.List<string> previousHandles = new 
    System.Collections.Generic.List<string>();
                System.Collections.Generic.List<string> currentHandles = new 
    System.Collections.Generic.List<string>();
                previousHandles.AddRange(driver.WindowHandles);
                elementToBeClicked.Click();
                Thread.Sleep(timer);
                for (int i = 0; i < 20; i++)
                {
                    currentHandles.Clear();
                    currentHandles.AddRange(driver.WindowHandles);
                    foreach (string s in previousHandles)
                    {
                        currentHandles.RemoveAll(p => p == s);
                    }
                    if (currentHandles.Count == 1)
                     {
                        driver.SwitchTo().Window(currentHandles[0]);
                        Thread.Sleep(100);
                        return currentHandles[0];
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }
                return null;
            }
