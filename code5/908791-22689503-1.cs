    public HttpResponseMessage Get()
    {
        return new HttpResponseMessage() { 
            Content = new StringContent("Hello World", System.Text.Encoding.UTF8, "application/json") 
        };
    }
