    public Task<HttpResponseMessage> Action()
    {
        return Task.Factory.StartNew(() =>
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Redirect);
            response.Headers.Location = new Uri("http://stackoverflow.com");
            return response;
        });
    }
