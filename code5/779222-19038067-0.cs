    public static IEnumerable<T> NoisyWrapper<T>(IEnumerable<T> source)
    {
        Console.WriteLine("Rabble rabble rabble!!!");
        foreach (var item in source)
            yield return item;
    }
