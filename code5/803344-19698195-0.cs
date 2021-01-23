    public class OneProp
    {
      private string val1;
      public string Value1 { get { return val1; } };
    
      private string val2;
      public string Value2 { get { return val2; } };
    
      public void SetValue(string propName, string propValue)
      {
       // null all values here
       val1 = null;
       val2 = null;
    
        switch(propName)
        {
          case "Value1":
          val1 = propValue;
          break;
    
          case "Value2":
          val1 = propValue;
          break;
        }
      }
    }
