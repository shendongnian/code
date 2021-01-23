    public abstract class MyCommonEventBase : EventArgs
    {
      public string generic_property { get; set; }
    }
    public class myclass01 : MyCommonEventBase
    {
      public string channel{get;set;}
    }
    public class myclass02 : MyCommonEventBase
    {
      public string extension{get;set;}
    }
