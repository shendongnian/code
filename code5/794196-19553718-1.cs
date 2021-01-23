    var doc = new HtmlDocument();
    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "GET";
    using (var response = (HttpWebResponse)request.GetResponse())
    {
        using (var stream = response.GetResponseStream())
        {
            doc.Load(stream);
        }
    }
    var table = doc.GetElementbyId("tblThreads");
