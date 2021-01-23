    webRequest = (HttpWebRequest)WebRequest.Create("http://" + Ip.ToString() + ":" + Port.ToString() + "........");
    webRequest.Method = "GET";
    webRequest.KeepAlive = true;
    webRequest.ContentType = "application/x-www-form-urlencoded";
    webRequest.CookieContainer = cookieJar;
    webResponse = (HttpWebResponse)webRequest.GetResponse();
    reader = new StreamReader(webResponse.GetResponseStream()); 
    string responseBody = reader.ReadToEnd();
    reader.Close();
    ServerInfo serverInfo = JsonConvert.DeserializeObject<ServerInfo>
    my_label_ServerInfo.Text = serverInfo.message;
