    public static void DisplayEntity<T>(T entity, params Func<T, Object>[] parm)
    {
        foreach (var func in parm)
            Console.WriteLine(func(entity).ToString());
    }
