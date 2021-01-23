        //should not be overridden
        public virtual void Dispose(){
          Dispose(true);
          GC.SuppressFinalize(this);
        }
        //must be overriden
        public abstract void Dispose(bool disposing);
