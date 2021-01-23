    public class Foo : IDisposable
    {
        TcpListener lst;
        bool disposed;
        public Foo()
        {
            lst = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 9090);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            // object will not be registered for finalization by GC
        }
        ~Foo()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
              return;
            
            if (disposing)                
                lst.Close();
            disposed = true;
        }
        // etc
    }
