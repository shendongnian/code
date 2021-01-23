    var request = (HttpWebRequest)WebRequest.Create("http://example.com/login");
    request.CookieContainer = cookieContainer;
    request.UserAgent = "Some User Agent";
    request.ContentType = "text/xml";
    request.Method = "POST";
    using (var stream = request.GetRequestStream())
    using (var writer = new StreamWriter(stream))
    {
        writer.Write("<foo>bar</foo>");
    }
    using (var response = request.GetResponse())
    using (var stream = response.GetResponseStream())
    using (var reader = new StreamReader(stream))
    {
        string body = reader.ReadToEnd();
        // the body will probably contain the SessionId you are looking for
        // go ahead, parse it and extract the necessary information
    }
