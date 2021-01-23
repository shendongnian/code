    public static void PrintLog(object obj = null,
           [CallerMemberName] string function = null,
           [CallerFilePath] string path = null)
    {
        string name = obj == null ? path : obj.GetType().Name;
        Console.WriteLine("Call from function {0}, name {1}", function, name);
    }
