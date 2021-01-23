    public class FileResult : IHttpActionResult
    {
        public FileResult(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));
            FilePath = filePath;
        }
        public string FilePath { get; }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(File.OpenRead(FilePath));
            var contentType = MimeMapping.GetMimeMapping(Path.GetExtension(FilePath));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return Task.FromResult(response);
        }
    }
