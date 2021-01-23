    public class Car : IDisposable
    {
    
       public void Dispose()
       {  
           // any other managed resource cleanups you can do here
           Gc.SuppressFinalize(this);
       }
    }
