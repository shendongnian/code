    abstract class Base<T>
    {
      public T Get(IParam parameter){
        return (this as dynamic).Provide(parameter as dynamic);
      }
    
      public abstract T Provide(IParam parameter);
    }
    
    class Impl<string> : Base<string>
    {
      public string Provide(IParam parameter)
      {
        return "default value";
      }
    
      public string Provide(ParamImplementation1 parameter)
      {
        return "value for implementation 1";
      }
    
      public string Provide(ParamImplementation2 parameter)
      {
        return "value for implementation 2";
      }
    }
