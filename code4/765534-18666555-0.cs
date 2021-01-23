    public class DisposableResourceHolder : IDisposable {
 
      private Socket socket; // handle to a resource
      public DisposableResourceHolder(){
          this.socket= ... // allocates the resource
      }
      public void Dispose(){
          Dispose(true);
          GC.SuppressFinalize(this);
        }
      protected virtual void Dispose(bool disposing){
          if (disposing){
              if (socket!= null) socket.Dispose(); // HERE DISPOSE
          }
      }
    }
