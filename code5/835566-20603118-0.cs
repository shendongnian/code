    HttpRequestMessage request = (input to handler)
    MediaTypeHeaderValue contentType = request.Content.Headers.ContentType;
    String body = request.Content.ReadAsStringAsync().Result;
    request.Content = new StringContent(body);
    request.Content.Headers.ContentType = contentType;
