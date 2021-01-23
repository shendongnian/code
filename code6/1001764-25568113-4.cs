    HttpClientHandler ch = new HttpClientHandler();
    
    HttpClient c = new HttpClient(ch);    
    c.DefaultRequestHeaders.TransferEncodingChunked = true;    
    c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes("user:pw")));
    
    Stream stream = new MemoryStream();
    
    AsyncStream asyncStream = new AsyncStream(); // Custom implementation of the PushStreamContent with the method, "WriteToStream()".
    
    PushStreamContent streamContent = new PushStreamContent(asyncStream.WriteToStream);
    
    HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://XXX") { Content = streamContent };
    
    requestMessage.Headers.TransferEncodingChunked = true;
    
    HttpResponseMessage response = await c.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
    
    // The request has been sent, since the first write in the "WriteToStream()" method.
    
    response.EnsureSuccessStatusCode();
    
    Task<Stream> result = response.Content.ReadAsStreamAsync();
    
    byte[] data = new byte[1028];
    
    int bytesRead;
    
    while ((bytesRead = await result.Result.ReadAsync(data, 0, data.Length)) > 0)
    {
        string output = System.Text.Encoding.UTF8.GetString(data, 0, bytesRead);
        
        Console.WriteLine(output);
    
    }
    
    Console.ReadKey();
