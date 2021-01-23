    public class GB : IDisposable
    {
        private StreamReader sr;
        private bool _isDisposed;
        
        public GB()
        {
            sr = new StreamReader(new FileStream("C:\\temp.txt", FileMode.Open, FileAccess.ReadWrite));
        }
        public int MultiCall()
        {
            if (sr.ReadLine() == "test1")
                return 1;
            else
                return 0;
        }
        
        ~GB()
        {
            Dispose(false);
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        private void Dispose(bool isManaged)
        {
            if(_isDisposed)
                return;
            
            if(isManaged)
            {
                // Ensure we close the file stream
                sr.Dispose();
            }
            
            _isDisposed = true;
        }
    }
