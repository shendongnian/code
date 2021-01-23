    public string HttpReturnJson(string url)
    {
        using (var request = WebRequest.Create(url))
        using (WebResponse response = request.GetResponse())
        using (var stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            string data = reader.ReadToEnd();
            return data;
        }
    }
