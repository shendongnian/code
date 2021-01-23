    using (var httpClient = new HttpClient())
    {
        string requestContent = string.Empty; // JSON Content comes here
        HttpContent httpContent = new StringContent(requestContent, Encoding.UTF8, "application/json");
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage(Verb, url);
        httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpRequestMessage.Content = request.Verb == HttpMethod.Get ? null : httpContent;
        response = httpClient.SendAsync(httpRequestMessage);
        var responseContent = await response.Result.Content.ReadAsStringAsync();
   }
