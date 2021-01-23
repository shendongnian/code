    public class BaseClass
    {
      public string GetName()
      {
        return string.Empty;
      }
    }
    
    public partial class ChildClass : BaseClass
    {  
      public string FullName;
      public int Marks;
    
      public new string GetName()
      {
        return FullName;
      }
    }
