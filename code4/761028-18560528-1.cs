    var RequestMessage = new HttpRequestMessage();
    RequestMessage.Content = new StringContent(YourPostData, Encoding.UTF8, "application/x-www-form-urlencoded");
    RequestMessage.Method = HttpMethod.Post;
    RequestMessage.RequestUri = new Uri(OtherRequestUri);
    Response = await Client.SendAsync(RequestMessage);
