    private static readonly MyContainerClass _instance = new MyContainerClass(); //true singleton
    private sealed class MyContainerClass //this is the singleton
    {
       private ISingletonClass _value = null;
       public ISingletonClass Value //threadsafe access to your object
       {
          get { lock(this){ return _value; } }
       }
       public ISingletonClass CreateOrUpdateValue(string id) //threadsafe updating of your object
       {
          if (id==null) throw new ArgumentNullException("id is missing!");
          lock(this)
          {
            var instance = _instance.Value;
            if (instance == null || instance.Id != id)
              _instance.Value = new SingletonClass(id);
            return _instance.Value;
           }
        }
    }
    public static void CreateOrUpdateInstance(string id)
    {
        _instance.CreateOrUpdateValue(id);
    }
    public static ISingletonClass GetInstance()
    {
        var instance = _instance.Value;
        if (instance == null)
           throw new Exception("Instance has not been created");
        return _instance;
    }
    // this is like your original method if you really want it
    public static ISingletonClass GetInstance(string id)
    {
        return _instance.CreateOrUpdateValue(id);
    }
