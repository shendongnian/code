    public static IEnumerable<T> Trace<T>(IEnumerable<T> values)
    {
        foreach (T value in values)
        {
            Console.WriteLine("Yielding {0}...", value);
            yield return value;
        }
    }
