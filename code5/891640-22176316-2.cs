    public Task<HttpResponseMessage> Post()
    {
        HttpRequestMessage request = this.Request;
        if (!request.Content.IsMimeMultipartContent())
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }
        var provider = new MultipartFormDataStreamProvider("C:\Temp");
        var task = request.Content.ReadAsMultipartAsync(provider).
            ContinueWith<HttpResponseMessage>(o =>
            {
                string file1 = provider.BodyPartFileNames.First().Value;
                // this is the file name on the server where the file was saved 
                return new HttpResponseMessage()
                {
                    Content = new StringContent("File uploaded.")
                };
            }
        );
        return task;
    }
