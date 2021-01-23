    public static IList<Double> GetKeys()
    {
        return new Double[] 
        {
            0.2,
            0.6, 
            0.9,
            10.58,
            -1.54,
            6.5
        }; 
    }
    public static IList<Double> GetValues()
    {
        return new Double[]
        {
            5.4,
            4.1,
            6.7,
            45.7,
            -7.02,
            6.66
        };
    }
    public static void Print<T>(IEnumerable<T> items)
    {
        if (items == null)
            throw new ArgumentNullException("items");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    public static void PrintKeyValues<TKey, TValue>(IEnumerable<TKey> keys, IEnumerable<TValue> values)
    {
        if (keys == null)
            throw new ArgumentNullException("keys");
        if (values == null)
            throw new ArgumentNullException("values");
        var pairs = keys
            .Zip(values,
                (key, value) =>
                    String.Format("[{0}] = {1}", key, value));
        Print(pairs);
    } 
    static void Main(string[] args)
    {
        var keys = GetKeys();
        var values = GetValues();
        Console.WriteLine("Before");
        PrintKeyValues(keys, values);
        Console.WriteLine();
        Console.WriteLine("After");
        var keysArray = keys.ToArray();
        var valuesArray = values.ToArray();
        Array.Sort(keysArray, valuesArray);
        PrintKeyValues(keysArray, valuesArray);
        Console.ReadKey();
    }
