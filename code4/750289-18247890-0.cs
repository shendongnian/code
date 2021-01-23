    static Action<T> MapField<T>()
    {
        // This will use Console.WriteLine(object) of course...
        return arg => Console.WriteLine(arg);
    }
    ...
    MapField<int>()(10);
