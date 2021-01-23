    public class Temp {
       private static readonly Lazy<Temp> instance = new Lazy<Temp>(() => new Temp());
    
       private void OnProcessExit(Object sender, EventArgs e) {
         // Release native resource if required:
         // some resources e.g. files will be closed automatically,
         // but some e.g. transactions should be closed (commit/rollback) manually
         try {  
           ...
         }
         finally { 
           AppDomain.CurrentDomain.ProcessExit = OnProcessExit;
         }   
       }
    
       private Temp() {
         // create IDisposable objects which use native resources
    
         // If you have to release some resouces on exit
         AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
       }
    
       public static Temp Instance {
         get {
           return instance.Value;
         }
       }
    } 
