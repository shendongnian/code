    private string GetHtmlCode()
    {
        var rnd = new Random();
        int topic = rnd.Next(0, _topics.Count - 1);
        string url = "https://www.google.com/search?q=" + _topics[topic] + "&tbm=isch";
        string data = "";
        var request = (HttpWebRequest)WebRequest.Create(url);
        var response = (HttpWebResponse)request.GetResponse();
        using (Stream dataStream = response.GetResponseStream())
        {
            if (dataStream == null)
                return "";
            using (var sr = new StreamReader(dataStream))
            {
                data = sr.ReadToEnd();
            }
        }
        return data;
    }
