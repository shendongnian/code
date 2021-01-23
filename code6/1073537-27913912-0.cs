    using (var requestStream = request.GetRequestStream())
    {
        string content = "Email=" + Username + "&Passwd=" + Password;
        requestStream.Write(Encoding.UTF8.GetBytes(content), 0, Encoding.UTF8.GetBytes(content).Length);
    }
    using (var sr = new StreamReader(request.GetResponse().GetResponseStream()))
    {
        string html = sr.ReadToEnd();
        string galxValue = ParseOutValue(html, "GALX");
        return GetLoginHtml2(galxValue, cookieJar);
    }
