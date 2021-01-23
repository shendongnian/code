    // Assuming your method is a POST and you are using JSON
    var httpWebRequest = WebRequest.Create("Your URL")
    httpWebRequest.Method = "POST";
    httpWebRequest.Accept = "application/json";
    httpWebRequest.ContentType = "application/json";
    List<string> responseValues = new List<string>();
    using (var httpWebResponse = httpWebRequest.GetResponse())
    {
        var responseStream = httpWebResponse.GetResponseStream();
        var streamReader = new StreamReader(responseStream);
        var responseContent = streamReader.ReadToEnd();
        responseValues = JsonConvert.DeserializeObject<List<string>(responseContent);
    }
    foreach (string response in responseValues)
    {
        ...
    }
