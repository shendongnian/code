    try
    {
        HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
        WebResponse wr = req.GetResponse();
    }
    catch (WebException wex)
    {
        var pageContent = new StreamReader(wex.Response.GetResponseStream())
                              .ReadToEnd();
    }
