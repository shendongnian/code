    public sealed class Foo : IDisposable
    {
        private int handle = 0;
        private bool disposed = false;
        public Foo()
        {
            Blah1();
            int x = AllocateResource();
            Blah2();
            this.handle = x;
            Blah3();
        }
        ~Foo()
        {
            Dispose(false);
        }
        public void Dispose() 
        { 
            Dispose(true); 
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (this.handle != 0) 
                    DeallocateResource(this.handle);
                this.handle = 0;
                this.disposed = true;
            }
        }
    }
