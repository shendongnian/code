    IWebElement menuOptions;
    menuOptions = _browserInstance.Driver.FindElement(By.XPath(".//*[@id='xxxxxxxxxxxxxxxxxx']/ul[2]/li[3]"));
    IList<IWebElement> list = menuOptions.FindElements(By.TagName("li"));
    //// get the column headers
    char[] character = "\r\n".ToCharArray();
    string[] Split = menuOptions.Text.Split(character);
    for (int i = 0; i < Split.Length; i++)
    {
        if (Split[i] != "")
        {
            _log.LogEntry("INFO", "column Text", true,
                    Split + " Text matches the expected:" + Split[i]);
        }
    }
