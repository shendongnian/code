    public class MyEnvironment {
    
        public string SomeVariable{
            get{
    
    #if DEBUG
               return "bar";
    #else
               return Environment.GetEnvironmentVariable("foo");
    #endif
    
            }
        }
    }
