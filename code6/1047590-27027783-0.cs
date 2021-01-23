    public static bool IsAt
        {
            get
            {
                try
                {
                    Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles.Last());
                    var DBViFrame = Driver.Instance.FindElement(By.Id("dashboardViewFrame"));
                    Driver.Instance.SwitchTo().Frame(DBViFrame);
                    var dataEntryButton = Driver.Instance.FindElement(By.Id("HyperlinkDataEntry"));
                    dataEntryButton.Click();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
