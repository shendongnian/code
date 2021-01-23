    string url = "some/url";
    var request = (HttpWebRequest)HttpWebRequest.Create(url);
    var webResponse = (HttpWebResponse)request.GetResponse();
    var responseStream = webResponse.GetResponseStream();
    var streamReader = new StreamReader(responseStream);  
    
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.Load(streamReader.ReadToEnd());
    
    var scripts = doc.DocumentNode.Descendants()
                                 .Where(n => n.Name == "script");
