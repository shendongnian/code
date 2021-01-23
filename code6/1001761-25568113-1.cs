    HttpClientHandler ch = new HttpClientHandler();
         HttpClient c = new HttpClient(ch);
         c.DefaultRequestHeaders.TransferEncodingChunked = true;
         c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes("user:pw")));
    
         Stream stream = new MemoryStream();
         var asyncStream = new AsyncStream(); //custom implementation for the PushStreamContent with the method "WriteToStream()"
         PushStreamContent streamContent = new PushStreamContent(asyncStream.WriteToStream);
         
         HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://XXX") { Content = streamContent };
         requestMessage.Headers.TransferEncodingChunked = true;
    
         HttpResponseMessage response = await c.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
