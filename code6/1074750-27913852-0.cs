    public class XYWrapper : X, Y
    {
    
      private dynamic InternalObject { get; set; }
      
      public void Foo() { InternalObject.Foo(); }
      public void Bar() { InternalObject.Bar(); }
    
      public static implicit operator XYWrapper(A value)
      {
        var instance = new XYWrapper();
        instance.InternalObject = value;
        return instance;
      }
    
      public static implicit operator XYWrapper(B value)
      {
        var instance = new XYWrapper();
        instance.InternalObject = value;
        return instance;
      }
    }
