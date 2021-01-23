    // Assuming your method is a POST and you are using JSON
    var httpWebRequest = WebRequest.Create("Your URL")
    httpWebRequest.Method = "POST";
    httpWebRequest.Accept = "application/json";
    httpWebRequest.ContentType = "application/json";
    string responseContent = String.Empty;
    using (var httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
    {
        var responseStream = httpWebResponse.GetResponseStream();
        var streamReader = new StreamReader(responseStream);
        
        responseContent = streamReader.ReadToEnd();
    }
