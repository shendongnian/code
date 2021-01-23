    public HttpResponseMessage Get()
    {
        var response = new HttpResponseMessage();
        response.Content = new StringContent("<html><body>Hello World</body></html>");
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
        return response;
    }
