    private static Type GetTypeFromHandle(IntPtr handle)
    {
        var method = typeof(Type).GetMethod("GetTypeFromHandleUnsafe", BindingFlags.Static | BindingFlags.NonPublic);
        return (Type)method.Invoke(null, new object[] { handle });
    }
    private static void Main(string[] args)
    {
        IntPtr handle = typeof(string).TypeHandle.Value;//Obtain handle somehow
        Type type = GetTypeFromHandle(handle);
    }
