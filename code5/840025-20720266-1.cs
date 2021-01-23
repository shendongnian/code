    public sealed class Program {
      private static Object s_SyncObj = new Object();
    
      private static volatile Program s_Instance;
    
      private Program() {
        ...    
      }
    
      public static Program Instance {
        get {
          if (!Object.ReferenceEquals(null, s_Instance)) 
            return s_Instance;
    
          lock (s_SyncObj) {
            if (!Object.ReferenceEquals(null, s_Instance)) 
              return s_Instance;
         
            s_Instance = new Program(); 
          }
    
          return s_Instance; 
        }
      }
    }
