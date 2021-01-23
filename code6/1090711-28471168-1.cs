      public class MyNextClass: IDisposable {
        protected virtual void Dispose(Boolean disposing) {
          ...
        }
    
        public void Dispose() {
          Dispose(true);
          GC.SuppressFinalize(this);   
        }
      }
      ...
      // compare this with the using() emulation in the code above
      using (MyNextClass n = new MyNextClass()) {
        ...
      }
  
