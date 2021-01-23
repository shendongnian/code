    var webRequest = (HttpWebRequest)WebRequest.Create("http://" + Ip.ToString() + ":" + Port.ToString() + "........");
    webRequest.Method = "GET";
    webRequest.KeepAlive = true;
    webRequest.ContentType = "application/x-www-form-urlencoded";
    webRequest.CookieContainer = cookieJar;
    var webResponse = (HttpWebResponse)webRequest.GetResponse();
    using (var stream = webResponse.GetResponseStream())
    using (var reader = new StreamReader(stream))
    {
        JsonSerializer serializer = new JsonSerializer();
        ServerInfo serverInfo = (ServerInfo)serializer.Deserialize(reader, typeof(ServerInfo));
        my_label_ServerInfo.Text = serverInfo.message;
    }
