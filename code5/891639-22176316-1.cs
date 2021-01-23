    public HttpResponseMessage Get()
    {
        var path = @"C:\Temp\file.zip";
        var result = new HttpResponseMessage(HttpStatusCode.OK);
        var stream = new FileStream(path, FileMode.Open);
        result.Content = new StreamContent(stream);
        result.Content.Headers.ContentType = 
            new MediaTypeHeaderValue("application/octet-stream");
    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                {
                                    FileName = "file.zip"
                                };
        return result;
    }
