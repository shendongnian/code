    public string getHTML(string url)
    {
     HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
     HttpWebResponse response = (HttpWebResponse)request.GetResponse();
     StreamReader sr = new StreamReader(response.GetResponseStream());
     string html = sr.ReadToEnd();
     sr.Close();
     response.Close();
     return html;
    }
