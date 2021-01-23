    abstract class Base
    {
      protected abstract string GetMessage();
    
      public sealed override string ToString()
      {
        return GetMessage();
      }
    }
    
    class Derived : Base
    {
      protected override string GetMessage()
      {
        return "hello";
      }
    }
