    public static void Log<T>(IList<T> objects)
    {
        foreach (var obj in objects)
        {
            Console.WriteLine(obj);
        }
    }  
