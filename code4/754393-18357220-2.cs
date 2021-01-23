    public static void Log(params object[] objects)
    {
        foreach (var obj in objects)
        {
            Console.WriteLine(obj);
        }
    }
