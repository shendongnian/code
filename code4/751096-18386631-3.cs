    public static void SendRequest(string myXml)
    {
        HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.CreateHttp("http://mytestserver.com/Test.php");
        webRequest.Method = "POST";
        webRequest.Headers["SOURCE"] = "WinApp";
        // Might not hurt to specify encoding here
        webRequest.ContentType = "text/xml; charset=utf-8";
        // ContentLength must be set before a stream may be acquired
        byte[] content = System.Text.Encoding.UTF8.GetBytes(myXml);
        webRequest.ContentLength = content.Length;
        var reqStream = await webRequest.GetRequestStreamAsync();
        reqStream.Write(content, 0, content.Length);
        var response = await httpRequest(webRequest);
    }
