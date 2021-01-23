    static Dictionary<Type, object> instances = new Dictionary<Type, object>();
    public static T GetControl<T> {
      T retVal = default(T);
      if (instances.ContainsKey(typeof(T)))
      {
        retVal = (T)instances[typeof(T)];
      }
      else
      {
        Type t = typeof(T);
        ConstructorInfo ci = t.GetConstructor(
          BindingFlags.Instance | BindingFlags.NonPublic,
          null, paramTypes, null);
        retVal = (T)ci.Invoke(null); // parameterless ctor needed
        instances.Add(typeof(T), retVal);
      }
 
      return retVal;
    }
