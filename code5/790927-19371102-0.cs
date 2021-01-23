    public static void GetSomeData(string webServiceProxyURL)
    {
        var request = WebRequest.Create(webServiceProxyURL);
        request.Method = "GET";
        request.ContentType = "application/json";
        string responseFromServer = "No response from server";
        using (var response = (HttpWebResponse) request.GetResponse())
        {
            using (var dataStream = response.GetResponseStream())
            {
                if (dataStream != null)
                {
                    using (var reader = new StreamReader(dataStream))
                    {
                        responseFromServer = reader.ReadToEnd();
                    }
                }
            }
        }
        Console.WriteLine("Response: \n" + responseFromServer);
    }
