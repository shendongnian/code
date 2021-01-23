    public HttpResponseMessage Post([FromBody] string value)
    {
        HttpResponseMessage response = new HttpResponseMessage();
        response.Content = new StringContent("Your message to me was: " + value);
        return response;
    }
