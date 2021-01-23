    public static void Log<T>(IEnumerable<T> objects)
    {
        foreach (var obj in objects)
        {
            Console.WriteLine(obj);
        }
    }  
