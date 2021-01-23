    public static void Log(IReadOnlyList<object> objects)
    {
        foreach (var obj in objects)
        {
            Console.WriteLine(obj);
        }
    }
