    // CA2213 does not detect
    class FieldIsInjected : IDisposable
    {
        private MemoryStream f;
        public FieldIsInjected(MemoryStream p)
        {
            f = p;
        }
        public void Dispose() { }
    }
