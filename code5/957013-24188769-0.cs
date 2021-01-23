    public CryptoStreamWrapper : Stream, IDisposable
    {
        public CryptoStreamWrapper(CryptoStream stream, RijndaelManaged rmCrypto, IDisposable transform)
        {
            this.transform = transform;
            this.rmCrypto = rmCrypto;
            this.stream = stream;
        }
    
        public void Dispose()
        {
            this.transform.Dispose();
            this.rmCrypto.Dispose();
            this.stream.Dispose();
        }
    }
