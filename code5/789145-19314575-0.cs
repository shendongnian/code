    using (var client = new WebClient())
    {
        // Append some custom header
        client.Headers[HttpRequestHeader.Authorization] = "Bearer some_key";
    
        string message = "some message to send";
        byte[] data = Encoding.UTF8.GetBytes(message);
    
        byte[] result = client.UploadData(data);
    }
