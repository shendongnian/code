    /// <summary>
        /// Creates a new instance of the <see cref="T:System.Net.Http.StringContent"/> class.
        /// </summary>
        /// <param name="content">The content used to initialize the <see cref="T:System.Net.Http.StringContent"/>.</param><param name="encoding">The encoding to use for the content.</param><param name="mediaType">The media type to use for the content.</param>
        [__DynamicallyInvokable]
        public StringContent(string content, Encoding encoding, string mediaType)
          : base(StringContent.GetContentByteArray(content, encoding))
        {
          this.Headers.ContentType = new MediaTypeHeaderValue(mediaType == null ? "text/plain" : mediaType)
          {
            CharSet = encoding == null ? HttpContent.DefaultStringEncoding.WebName : encoding.WebName
          };
        }
