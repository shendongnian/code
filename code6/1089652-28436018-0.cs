    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void SendRequest (string query, string table)
    {
        string address = "http://localhost:9000/api/search";
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(address);
        request.ContentType = "application/json; charset=utf-8";
        request.Method = "POST";
        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            string json = "{\"Query\":\""+query+"\",\"Table\":\""+table+"\"}";
            streamWriter.Write(json);
            streamWriter.Flush();
        }
        var httpResponse = (HttpWebResponse)request.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
        }
    }
