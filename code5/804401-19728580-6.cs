    [HttpPost]
    public Task<string> Post()
    {
        if (!Request.Content.IsMimeMultipartContent())
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "Invalid Request!"));
        var provider = new MultipartFormDataMemoryStreamProvider();
        return Request.Content.ReadAsMultipartAsync(provider).ContinueWith(p =>
        {
            var result = p.Result;
            var myParameter = result.FormData.GetValues("myParameter").FirstOrDefault();
            foreach (var stream in result.Contents.Where((content, idx) => result.IsStream(idx)))
            {
                var file = new FileData(stream.Headers.ContentDisposition.FileName);
                var contentTest = stream.ReadAsByteArrayAsync();
                // ... and so on, as per your original code.
                
            }
            return myParameter;
        });
    }
