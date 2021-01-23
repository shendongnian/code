    protected static IDictionary<Assembly,string> MyProperties =
        new Dictionary<Assembly,string>();
    public static string MyProperty {
        set {
           MyProperties[Assembly.GetCallingAssembly()] = value;
        }
        get {
           return MyProperties[Assembly.GetCallingAssembly()];
        }
    }
