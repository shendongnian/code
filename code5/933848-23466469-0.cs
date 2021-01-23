        private readonly ApiController _controller;
        public OkXmlDownloadResult(string xml, string downloadFileName,
            ApiController controller)
        {
            if (xml == null)
            {
                throw new ArgumentNullException("xml");
            }
            if (downloadFileName == null)
            {
                throw new ArgumentNullException("downloadFileName");
            }
            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }
            Xml = xml;
            ContentType = "application/xml";
            DownloadFileName = downloadFileName;
            _controller = controller;
        }
        public string Xml { get; private set; }
        public string ContentType { get; private set; }
        public string DownloadFileName { get; private set; }
        public HttpRequestMessage Request
        {
            get { return _controller.Request; }
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }
        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(Xml);
            response.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(ContentType);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = DownloadFileName
            };
            return response;
        }
    }
