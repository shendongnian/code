    class BaseTool
    {
      public static T Create<T>(string Arg1, string Arg2) where T : BaseTool, new()
      {
        var instance = new T();
        // do stuff, to instance (which is a BaseTool)
        return instance;
      }
      public static T Create<T>(string Arg1) where T : BaseTool, new()
      {
        var instance = new T();
        // do stuff, to instance (which is a BaseTool)
        return instance;
      }
      public static T Create<T>(int Arg1) where T : BaseTool, new()
      {
        var instance = new T();
        // do stuff, to instance (which is a BaseTool)
        return instance;
      }
    }
