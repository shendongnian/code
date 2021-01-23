      public static bool InitializeAndSetupBrowser(string proxyIp, string proxyUsername, string proxyPassword, string proxyPort)
        {
        try
        {
            var proxy = new
            {
                Ip = proxyIp,
                Username = proxyUsername,
                Password = proxyPassword,
                Port = proxyPort
            };
            string PROXY = proxy.Ip + ":" + proxy.Port;
            Proxy pro = new Proxy();
            pro.HttpProxy = PROXY;
            pro.FtpProxy = PROXY;
            pro.SslProxy = PROXY;
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.Proxy = pro;
            PropertiesCollection.Driver = new FirefoxDriver(firefoxOptions);
            Navigate(""); //this method is my internal method, just navigate in to page, this makes the proxy credentials dialog to appear
            try
            {
                WebDriverWait wait = new WebDriverWait(PropertiesCollection.Driver, TimeSpan.FromSeconds(15));
                wait.Until(ExpectedConditions.AlertIsPresent());
                IAlert alert = PropertiesCollection.Driver.SwitchTo().Alert();
                alert.SendKeys(proxy.Username + Keys.Tab + proxy.Password);
                alert.Accept();
            }
            catch { }
            return true;
        }
        catch (Exception exc)
        {
            Logger.Log("Could not start browser.", exc);
            return false;
        }
    }
