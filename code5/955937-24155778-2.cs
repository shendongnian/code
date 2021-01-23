    public static void SetValueFromProperty<T>(this object obj, string Name, T value)
    {
      var methods = Name.Split('.');
      
      object current = obj;
      object result = null;
      PropertyInfo prop = null;
      for(int i = 0 ; i < methods.Length - 1  ; ++i)
      {
      	var method = methods[i];
      	prop = current.GetType().GetProperty(method);
        result = prop != null ? prop.GetValue(current, null) : null;
        current = result;
      }
      if(methods.Length > 0)
        prop = current.GetType().GetProperty(methods[methods.Length - 1]);
      if(null != prop)
          prop.SetValue(current, value, null);
    }
