    private static void InitializeServiceLocator()
    {
        if (ServiceLocator == null)
        {
            var ip = "";
            var deviceType = TestSetupHelper.DeviceSelector["iphone7"];
            var capabilities = TestSetupHelper.SetAppiumCababilities(deviceType, Locale);
            string server = MSTestContextSupport.GetRunParameter("appiumServer");
            var port = Convert.ToInt32(MSTestContextSupport.GetRunParameter("appiumPort"));
            if (Locale != "sauce")
            {
                ip = TestSetupHelper.GetComputerIpAddress(server, port, true);
            }
            var kernel = new StandardKernel();
            kernel.Bind<IOSDriver<AppiumWebElement>>().ToConstructor(x => new IOSDriver<AppiumWebElement>(new Uri("http://" + ip + ":" + port + "/wd/hub"), capabilities, TimeSpan.FromMinutes(10))).Named("AppiumDriver");
            kernel.Bind<IOSDriver<AppiumWebElement>>().ToConstructor(x => new IOSDriver<AppiumWebElement>(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), capabilities, TimeSpan.FromMinutes(10))).Named("AppiumSauceDriver");
            ServiceLocator = new NinjectServiceLocator(kernel);
            Microsoft.Practices.ServiceLocation.ServiceLocator.SetLocatorProvider(() => ServiceLocator);
        }
    }
