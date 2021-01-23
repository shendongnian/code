    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;
    ...
    public string Get()
    {
        // c:\phantomjs contains phantomjs.exe
        // if blank, Web Driver will download the latest version
        IWebDriver driver = new PhantomJSDriver(@"c:\phantomjs");
        driver.Navigate().GoToUrl("http://stackoverflow.com/");
        string title = driver.Title;
        driver.Quit();
        return title;
    }
