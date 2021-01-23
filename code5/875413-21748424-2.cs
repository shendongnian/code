    /// <summary>
    /// Performs the actual request to the dyndns server to update the entity
    /// </summary>
    /// <param name="url">url to post</param>
    private String PerformUpdate(String url)
    {
       HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
       NetworkCredential creds = new NetworkCredential(Username, Password);
       request.UserAgent = Username + " - " + Password + " - " + "0.01";
       request.Credentials = creds;
       request.Method = "GET";
       HttpWebResponse response = request.GetResponse() as HttpWebResponse;
       Stream reply = response.GetResponseStream();
       StreamReader readReply = new StreamReader(reply);
       return readReply.ReadToEnd();
    }
