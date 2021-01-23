    public class DisposableResourceHolder : IDisposable {
     
        private SafeHandle resource; // handle to a resource
    
        public DisposableResourceHolder(){
            this.resource = ... // allocates the resource
        }
    
        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing){
            if (disposing){
                if (resource!= null) resource.Dispose();
            }
        }
    }
