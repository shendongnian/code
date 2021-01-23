    public class TypeHintValueProvider : IValueProvider
    {
            
      private readonly string _value;
      public TypeHintValueProvider(string value)
      {
        _value = value;
      }
      public void SetValue(object target, object value)
      {        
      }
      
      public object GetValue(object target)
      {
        return _value;
      }
    }
