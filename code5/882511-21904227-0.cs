    public static async Task<string> GetStatusCode(string url)
    {
        var request = (HttpWebRequest)WebRequest.Create(url);
            
        try
        {
            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            {
                return response.StatusCode.ToString();
            }
        }
        catch (WebException ex)
        {
            return ex.Status == WebExceptionStatus.ProtocolError ?
                    ((HttpWebResponse)e.Response).StatusCode.ToString() : null;
        }
    }
