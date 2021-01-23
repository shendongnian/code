    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using System.Windows.Automation;//you need to add UIAutomationTypes and UIAutomationClient to references
    using System.Runtime.InteropServices;
    [DllImport("User32.dll")]
    static extern int SetForegroundWindow(IntPtr point);
    private IntPtr getIntPtrHandle(IWebDriver driver, int timeoutSeconds = 30)
    {
            var end = DateTime.Now.AddSeconds(timeoutSeconds);
            while (DateTime.Now < end)
            {
                var ele = AutomationElement.RootElement;
                foreach (AutomationElement child in ele.FindAll(TreeScope.Children, Condition.TrueCondition))
                {
                    if (!child.Current.Name.Contains(driver.Title)) continue;
                    return new IntPtr(child.Current.NativeWindowHandle);
                }
            }
            return IntPtr.Zero;
    }
    private void downloadCaptcha(IWebDriver chromeDriver)
    {
        OpenQA.Selenium.IWebElement captchaImage = chromeDriver.FindElement(By.Id("secimg0"));
        var handle = getIntPtrHandle(chromeDriver);
        SetForegroundWindow(handle);//you need a p/invoke 
        Thread.Sleep(1500);//setting foreground window takes time
        Actions action = new Actions(chromeDriver);
        action.ContextClick(captchaImage).Build().Perform();
        Thread.Sleep(300);
        SendKeys.Send("V");
        var start = Environment.TickCount;
        while (Environment.TickCount - start < 2000)
        {//can't use Thread.Sleep here, alternatively you can use a Timer
              Application.DoEvents();
        }
        SendKeys.SendWait(@"C:\temp\vImage.jpg");
        SendKeys.SendWait("{ENTER}");
    }
