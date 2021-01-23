    public class MultipartFormFile
    {
        public string Name { get; set; }
        public long? Length { get; set; }
        public string MediaType { get; set; }
        public Stream Stream { get; set; }
    }
    public class MultipartFormDataMemoryStreamProvider : MultipartMemoryStreamProvider
    {
        private readonly Collection<bool> _isFormData = new Collection<bool>();
        private readonly NameValueCollection _formData = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
        private readonly List<MultipartFormFile> _fileStreams = new List<MultipartFormFile>();
        public NameValueCollection FormData
        {
            get { return _formData; }
        }
        public List<MultipartFormFile> FileStreams
        {
            get { return _fileStreams; }
        }
        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }
            if (headers == null)
            {
                throw new ArgumentNullException("headers");
            }
            var contentDisposition = headers.ContentDisposition;
            if (contentDisposition == null)
            {
                throw new InvalidOperationException("Did not find required 'Content-Disposition' header field in MIME multipart body part.");
            }
            _isFormData.Add(String.IsNullOrEmpty(contentDisposition.FileName));
            return base.GetStream(parent, headers);
        }
        public override async Task ExecutePostProcessingAsync()
        {
            for (var index = 0; index < Contents.Count; index++)
            {
                HttpContent formContent = Contents[index];
                if (_isFormData[index])
                {
                    // Field
                    string formFieldName = UnquoteToken(formContent.Headers.ContentDisposition.Name) ?? string.Empty;
                    string formFieldValue = await formContent.ReadAsStringAsync();
                    FormData.Add(formFieldName, formFieldValue);
                }
                else
                {
                    // File
                    var file = new MultipartFormFile
                    {
                        Name = UnquoteToken(formContent.Headers.ContentDisposition.FileName),
                        Length = formContent.Headers.ContentLength,
                        MediaType = formContent.Headers.ContentType.MediaType,
                        Stream = await formContent.ReadAsStreamAsync()
                    };
                    FileStreams.Add(file);
                }
            }
        }
        private static string UnquoteToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return token;
            }
            if (token.StartsWith("\"", StringComparison.Ordinal) && token.EndsWith("\"", StringComparison.Ordinal) && token.Length > 1)
            {
                return token.Substring(1, token.Length - 2);
            }
            return token;
        }
    }
