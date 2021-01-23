    public class MyClass : IDisposable
    {
       private WebServiceHost m_WebServiceHost;
    
       // Often you have to override Dispose method 
       protected virtual void Dispose(Boolean disposing) {
         if (disposing) {
           // It looks that WebServiceHost implements IDisposable explicitly
           IDisposable disp = m_WebServiceHost as IDisposable;
    
           if (!Object.RefrenceEquals(null, disp))
             disp.Dispose();
    
           // May be useful when debugging
           disp = null;       
         }
       }
    
       // Members
       public void Dispose()
       {
         Dispose(true);
         GC.SuppressFinalize(this);
       }
    }
