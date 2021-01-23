        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            
            if(!disposed)
            {
                if(disposing)
                {
                    // destroy managed objects here...
                }
                disposed = true;
            }
        }
        ~NameOfClass()
        {
            Dispose(false);
        }
