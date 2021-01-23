    protected virtual HttpResponseMessage Download(string fileName, string contentType
        , byte[] data)
    {
        var path = fileName;
        var result = new HttpResponseMessage(HttpStatusCode.OK);
        var stream = new MemoryStream(data);
        result.Content = new StreamContent(stream);
        result.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        result.Content.Headers.Add("Content-Disposition", "attachment; fileName=" + path);
        return result;
    }
