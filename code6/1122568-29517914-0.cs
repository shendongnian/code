    public static bool IsElementDisplayedByXpathVariableWait(string xpath, int iterations)
        {
    bool returnVal = false; 
    string lastExceptionMessage = string.Empty;
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
                    lastExceptionMessage = e.Message;
                    Wait(1000);
                    continue;
                }
            }
            if (lastExceptionMessage != string.Empty)
                LNLog(lastExceptionMessage, Level.Error);
            return returnVal;
    }
