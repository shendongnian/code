    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost/CONTROLLER_NAME/ReceiveJson");
    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "GET";
    
    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    {
        string json = new JavaScriptSerializer().Serialize(myObject);
    
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    
        // If you need to read response
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
        }
    }
