    string result = "";
    using (var client = new WebClient())
    {
        client.Headers[HttpRequestHeader.ContentType] = "application/json"; 
        result = client.UploadString(url, "POST", json);
    }
    Console.WriteLine(result);
