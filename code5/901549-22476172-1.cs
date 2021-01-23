    static Dictionary<Type, object> instances = new Dictionary<Type, object>();
    public static T GetControl<T> where T: new() {
      T retVal = default(T);
      if (instances.ContainsKey(typeof(T)))
      {
        retVal = (T)instances[typeof(T)];
      }
      else
      {
        retVal = new T();
        instances.Add(typeof(T), retVal);
      }
 
      return retVal;
    }
       
