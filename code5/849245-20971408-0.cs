    WebClient client = new WebClient();
    try
    {
        client.DownloadString(url);
    }
    catch (System.Net.WebException exception)
    {
        string responseText;
    
        using (var reader = new System.IO.StreamReader(exception.Response.GetResponseStream()))
        {
            responseText = reader.ReadToEnd();
            throw new Exception(responseText);
        }
    }
               
