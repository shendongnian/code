    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using System.Reactive.Linq;
    
    public static class SeleniumUtil
    {
       public static void Highlight(this  IWebElement context)
        {
            var rc = (RemoteWebElement)context;
            var driver = (IJavaScriptExecutor)rc.WrappedDriver;
            var script = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: red""; ";
            driver.ExecuteScript(script, rc);
            Observable.Timer(new TimeSpan(0, 0, 3)).Subscribe(p =>
            {
                var clear = @"arguments[0].style.cssText = ""border-width: 0px; border-style: solid; border-color: red""; ";
                driver.ExecuteScript(clear, rc);
            });
        }
    }
