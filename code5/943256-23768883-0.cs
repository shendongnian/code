    public class FileResult : IHttpActionResult
    {
        private readonly string filePath;
        private readonly string contentType;
        public FileResult(string filePath, string contentType = null)
        {
            this.filePath = filePath;
            this.contentType = contentType;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(File.OpenRead(filePath))
                };
                var contentType = this.contentType ?? MimeMapping.GetMimeMapping(Path.GetExtension(filePath));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                return response;
            }, cancellationToken);
        }
    }
