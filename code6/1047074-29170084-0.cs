    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
    req.Headers[HttpRequestHeader.Authorization] = "basic " +
                Convert.ToBase64String(
                Encoding.ASCII.GetBytes(
                string.Format("{0}|{1}", "login", "password")));
    string result = string.Empty;
    using (WebResponse resp = (HttpWebResponse)req.GetResponse())
    {
        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
        {
            result = sr.ReadToEnd();
        }
    }
