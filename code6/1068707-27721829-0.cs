    //Createing instans of web client
    WebClient wc = new WebClient();
    //Getting the html content of the whattsap application page for android
    string HtmlString = wc.DownloadString("http://www.whatsapp.com/android");
    //Loading the html content into HtmlAgilityPack HTML Document
    HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
    htmlDoc.LoadHtml(HtmlString);
    //Extracting The latest version string from the HTML content by searching the "P" with class named version
    //and retriving it's inner text.
    _currentVersion = htmlDoc.DocumentNode.Descendants("p").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("version")).First().InnerText;
    //removing the "Version" keyword from the version string so we can get only rhe version number
    _currentVersion = _currentVersion.Replace("Version", "").Trim();
