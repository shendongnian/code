    HttpWebRequest webReq = (HttpWebRequest)HttpWebRequest.Create(linkUrl);
    try
    {
        webReq.CookieContainer = new CookieContainer();
        webReq.Method = "GET";
        using (WebResponse response = webReq.GetResponse())
        {
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                res = reader.ReadToEnd();
                ...
            }
        }
    }
    catch (Exception ex)
    {
        ...
    }
