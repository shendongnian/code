    public Stream SendRequest(string Url)
    {
        HttpWebRequest WebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
    
        // Set default values here. Removed for clarity
        // Get Method etc
    
        var WebResponse = (System.Net.HttpWebResponse)WebRequest.GetResponse();
        
        m_StatusCode = WebResponse.StatusCode;
        
        return WebResponse.GetResponseStream();
    }
