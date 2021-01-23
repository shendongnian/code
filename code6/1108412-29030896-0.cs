    public class Base
    {
      public Base()
      {
        var baseA = typeof (Base).GetRuntimeMethod("MethodA", new Type[0]);
        var baseB = typeof (Base).GetRuntimeMethod("MethodB", new Type[0]);
        var derivedA = GetType().GetRuntimeMethod("MethodA", new Type[0]);
        var derivedB = GetType().GetRuntimeMethod("MethodB", new Type[0]);
  
        if (baseA.DeclaringType == derivedA.DeclaringType ^ 
            baseB.DeclaringType == derivedB.DeclaringType)
          throw new InvalidOperationException("You must override MethodA and MethodB together.");
      }
  
      public virtual string MethodA() { return "Hello"; }
      public virtual int MethodB() { return 123; }
    }
