    HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
    request.Timeout = 15000;
    request.Method = "HEAD"; // As per Lasse's comment
    try
    {
        using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
        {
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
    catch (WebException)
    {
        return false;
    }
