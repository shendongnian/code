    /// <summary>
    /// Creates a class that creates a <see cref="CryptoStream"/> and wraps the disposing action of all the associated objects 
    /// </summary>
    class ReturnableCryptoStream : CryptoStream
    {
        private readonly ICryptoTransform _transform;
        private readonly IDisposable _algorithm;
        public ReturnableCryptoStream(Stream stream, ICryptoTransform transform, CryptoStreamMode mode) 
            : this(stream, transform, mode, null)
        {
        }
        public ReturnableCryptoStream(Stream stream, ICryptoTransform transform, CryptoStreamMode mode, IDisposable algorithm) 
            : base(stream, transform, mode)
        {
            _transform = transform;
            _algorithm = algorithm;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_transform != null)
                    _transform.Dispose();
                if (_algorithm != null)
                    _algorithm.Dispose();
            }
        }
    }
