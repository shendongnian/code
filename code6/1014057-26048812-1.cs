        private bool disposed = false;
        protected virtual void Dispose(bool disposing) 
        {
            if (!this.disposed) 
            {
                if (disposing)
                   context.Dispose(); // <-- dispose
            }
            this.disposed = true;
        }
        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
