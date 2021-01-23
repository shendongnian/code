    private static StreamContent addStreamContent(Stream stream, string filename )
        {
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"file\"",
                FileName = "\""+filename+"\""
            };
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return fileContent;
        }
    private static StringContent addStringContent(string name, string content)
    {
        var fileContent = new StringContent(content);
        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
        {
            Name = "\"" + name + "\""
        };
        return fileContent;
    }
