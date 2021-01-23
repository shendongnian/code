    public static void Log(int errorLevel, string message)
    {
        Console.WriteLine(message);
    }
    public void Test()
    {
        var lua = new Lua();
        lua.RegisterFunction("Log", this, GetType().GetMethod("Log"));
        lua.DoString("function foo() Log('a','b') end");
        lua.GetFunction("foo").Call();
    }
