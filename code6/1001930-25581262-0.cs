    public static string SendXMLFile(string xmlFilepath, string uri, int timeout)
    {
        using (var client = new WebClient())
        {                
            client.Headers.Add("Content-Type", "application/xml");                
            byte[] response = client.UploadFile(uri, "POST", xmlFilepath);
            return Encoding.ASCII.GetString(response);
        }
    }
