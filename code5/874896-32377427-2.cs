    public static string AssemblyGUID
    {
      get {
        var assembly = Assembly.GetExecutingAssembly();
        var attribute = (System.Runtime.InteropServices.GuidAttribute)assembly.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), true)[0];
        var GUID = attribute.Value;
        return GUID;
      }
    }
