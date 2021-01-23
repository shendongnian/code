    using (var content = new MultipartFormDataContent())
    {
        content.Add(CreateFileContent(imageStream, fileName, "image/jpeg"));
    }
    private StreamContent CreateFileContent(Stream stream, string fileName, string contentType)
    {
        var fileContent = new StreamContent(stream);
        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") 
        { 
            Name = "\"files\"", 
            FileName = "\"" + fileName + "\""
        };
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);            
        return fileContent;
    }
