    //Run selenium
    ChromeDriver cd = new ChromeDriver(@"chromedriver_win32");
    cd.Url = @"https://fif.com/login";
    cd.Navigate();
    IWebElement e = cd.FindElementById("username");
    e.SendKeys("...");
    e = cd.FindElementById("password");
    e.SendKeys("...");
    e = cd.FindElementByXPath(@"//*[@id=""main""]/div/div/div[2]/table/tbody/tr/td[1]/div/form/fieldset/table/tbody/tr[6]/td/button");
    e.Click();
    //Get the cookies
    foreach(OpenQA.Selenium.Cookie c in cd.Manage().Cookies.AllCookies)
    {
        string name = c.Name;
        string value = c.Value;
        cc.Add(new System.Net.Cookie(name,value,c.Path,c.Domain));
    }
    //Fire off the request
    HttpWebRequest hwr = (HttpWebRequest) HttpWebRequest.Create("https://fif.com/components/com_fif/tools/capacity/values/");
    hwr.CookieContainer = cc;
    hwr.Method = "POST";
    hwr.ContentType = "application/x-www-form-urlencoded";
    StreamWriter swr = new StreamWriter(hwr.GetRequestStream());
    swr.Write("feeds=35");
    swr.Close();
    WebResponse wr = hwr.GetResponse();
    string s = new System.IO.StreamReader(wr.GetResponseStream()).ReadToEnd();
