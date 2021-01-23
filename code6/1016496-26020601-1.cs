    class Foo : IDisposable {
        protected virtual void Dispose(bool disposing) {
            // Your cleanup code goes here.
        }
        public void Dispose() {
            GC.SuppressFinalize(this);
            Dispose(true);
        }
        ~Foo() {
            Dispose(false);
        }
    }
