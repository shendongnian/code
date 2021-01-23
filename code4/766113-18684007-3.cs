    public delegate bool Parser<T>(string s, out T result);
    public static T GetParsedValueOrDefault<T>(string val, Parser<T> parser)
    {
        T result;
        bool success = parser(val, out result);
        return success ? result : default(T);
    }
    // Examples
    int result = GetParsedValueOrDefault<int>("123", int.TryParse);
    Console.WriteLine(result); // "123"
    decimal result = GetParsedValueOrDefault<decimal>("123.546", decimal.TryParse);
    Console.WriteLine(result); // "123.456"
    decimal result = GetParsedValueOrDefault<decimal>("invalid", decimal.TryParse);
    Console.WriteLine(result); // "0.0"
