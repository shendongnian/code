    public static T create<T>() where T : new()
    {
      T obj = new T();
      Type myType = typeof(T);
      FieldInfo myFieldInfo = myType.GetField("client_no");
      myFieldInfo.SetValue(obj, CLIENT_NUMBER);                        
      return obj;
    }
