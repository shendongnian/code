    public class Variables
    {
      private static Variables instance = new Variables();
    
      public static Variables Instance
      {
        get
        {
          return instance;
        }
      }
    
      public string[] GlobalArray { get; set; } 
    }
    
    // Usage
    var myGlobalArray = Variables.Instance.GlobalArray;
