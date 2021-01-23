    private bool IfURLExists(string url)
    {
        try
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "HEAD";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return (response.StatusCode == HttpStatusCode.OK);
        }
        catch //may catch specific WebException First
        {
            return false;
        }
    }
