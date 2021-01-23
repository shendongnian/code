    public static bool IsElementDisplayedByXpathVariableWait(string xpath, int iterations)
        {
    bool returnVal = false;   
            int tracker = 0;
            while (tracker < iterations)
            {
                try
                {
                    tracker++;
                    IWebElement pageObject = _driver.FindElement(By.XPath(xpath));
                    if (pageObject.Displayed)
                    {
                        returnVal = true;
                        break;
                    }
                }
                catch (Exception e)
                {                   
                    Wait(1000);
                    continue;
                }
            }           
            return returnVal;
    }
