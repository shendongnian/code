    /// <summary>
    /// Creates a class that creates a <see cref="CryptoStream"/> and wraps the disposing action of all the associated objects 
    /// </summary>
    class ReturnableCryptoStream : CryptoStream
    {
        private readonly ICryptoTransform _transform;
        private readonly IDisposable _algorithom;
        public ReturnableCryptoStream(Stream stream, ICryptoTransform transform, CryptoStreamMode mode, IDisposable algorithom) 
            : base(stream, transform, mode)
        {
            _transform = transform;
            _algorithom = algorithom;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_transform != null)
                    _transform.Dispose();
                if (_algorithom != null)
                    _algorithom.Dispose();
            }
        }
    }
