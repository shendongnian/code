    var version = new Version(webBrowser.Document.Body.InnerText);
    // or alternatively:
    //var version = Version.Parse(webBrowser.Document.Body.InnerText);
    Console.WriteLine(version);
    
