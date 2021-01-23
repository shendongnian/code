    string url = "http://myUrl.com/page";
    string parameters = "param1=un&param2=ooohyé"
    byte[] bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(parameters);
    WebRequest webRequest = WebRequest.Create(url);
    webRequest.Method = "POST";
    webRequest.ContentType = "application/x-www-form-urlencoded";
    webRequest.ContentLength = bytes.Length;
    Stream paramStream = webRequest.GetRequestStream();
    paramStream.Write(bytes, 0, bytes.Length);
    paramStream.Close();
    WebResponse response = webRequest.GetResponse();
