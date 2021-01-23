    var request = new HttpRequestMessage(HttpMethod.Post, "http://www.something.com");
    request.Content = new StringContent("Hello World!");
            
    var serializedRequestByteArray = new HttpMessageContent(request).ReadAsByteArrayAsync().Result;
    var tmpRequest = new HttpRequestMessage();
    tmpRequest.Content = new ByteArrayContent(serializedRequestByteArray);
    tmpRequest.Content.Headers.Add("Content-Type", "application/http;msgtype=request");
    var deserializedRequest = tmpRequest.Content.ReadAsHttpRequestMessageAsync().Result;  
