    PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
    service.IgnoreSslErrors = true;
    service.LoadImages = false;
    // Not sure I'd use Start here. The constructor will start the service
    // for you.
    service.Start();
    // Use the IWebDriver interface. There's no real advantage to using
    // the PhantomJSDriver class.
    IWebDriver ghostDriver = new PhantomJSDriver(service);
    // ...
    List<string> retVal = new List<string>();
    var aElements = ghostDriver.FindElements(By.XPath("//div[@id='menu']//a[@href]"));
    // Use the IWebElement interface here. The concrete PhantomJSWebElement
    // implementation gives you no advantages over coding to the interface.
    foreach(IWebElement link in aElements)
    {
        try
        {
            retVal.Add(link.GetAttribute("href"));
        }
        catch (Exception)
        {
            continue;
        }
    }
