    /// <summary>
    /// Creates and empty filter for HttpResponse.Filter (i.e no proessing is done on the text before writting to the stream)
    /// </summary>
    class EmptyFilter : MemoryStream
    {
        private string source = string.Empty;
        private readonly Stream filter;
        public EmptyFilter(HttpResponse httpResponseBase)
        {
            this.filter = httpResponseBase.Filter;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            this.source = Encoding.UTF8.GetString(buffer);
            this.filter.Write(Encoding.UTF8.GetBytes(this.source), offset, Encoding.UTF8.GetByteCount(this.source));
        }
    }
