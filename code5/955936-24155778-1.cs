    public static string GetValueFromProperty(this object obj, string Name)
    {
      var methods = Name.Split('.');
      
      object current = obj;
      object result = null;
      foreach(var method in methods)
      {
      	var prop = current.GetType().GetProperty(method);
        result = prop != null ? prop.GetValue(current, null) : null;
        current = result;
      }
      return result == null ? string.Empty : result.ToString();
    }
