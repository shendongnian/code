    struct MyNullable<T>
    {
      private bool hasValue;
      private T value;
      
      public static MyNullable<T> FromValue(T value) 
      { 
        return new MyNullable<T>() { hasValue = true, value = value }; 
      }
       
      public static implicit operator T (MyNullable<T> n) 
      {
        return n.value;
      }
    }
    
    private bool IsMyNullable(object obj)
    {
        if (obj == null) return true; // Duh
        var type = obj.GetType().Dump();
        return type.IsGenericType 
               && type.GetGenericTypeDefinition() == typeof(MyNullable<>);
    }
