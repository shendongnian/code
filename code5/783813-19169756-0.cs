    public static void MyMethod<T>( IDictionary<string,object> dictionary , string key , ref T destination )
    {
      object value ;
      bool   found = dictionary.TryGetValue( key , out value ) ;
      
      if (found && value is T)
      {
        destination = (T) value ;
      }
      
      return;
    }
