    public class ComplexResourceHolder : IDisposable {
     
        private IntPtr buffer; // unmanaged memory buffer
        private SafeHandle resource; // disposable handle to a resource
            
        public ComplexResourceHolder(){
            this.buffer = ... // allocates memory
            this.resource = ... // allocates the resource
        }
    
        protected virtual void Dispose(bool disposing){
                ReleaseBuffer(buffer); // release unmanaged memory
            if (disposing){ // release other disposable objects
                if (resource!= null) resource.Dispose();
            }
        }
     
        ~ ComplexResourceHolder(){
            Dispose(false);
        }
     
        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
