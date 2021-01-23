    abstract class Base<T>
    {
      public abstract string ToString<T>(T t);
      public void DoSomething(T t)
      {
        string myValue = ToString(t);
        ...
      }
    }
    
    class MyClass : Base<MyObj>
    {
      public override string ToString(MyObj o)
      {
         return o.Name;
      }
    }
    
    class MyClass2 : Base<MyObj2>
    {
      public override string ToString(MyObj2 o)
      {
         return o.Value;
      }
    }
