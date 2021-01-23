    public delegate bool Parser<T>(string s, out T result);
    public static bool GetParsedValueOrDefault<T>(string val, Parser<T> parser, out T result)
    {
        result = default(T);
        T parsedResult;
        bool success = parser(val, out parsedResult);
        if (success)
        {
            result = parsedResult;
        }
        return success;
    }
    // Examples
    int result;
    GetParsedValueOrDefault("123", int.TryParse, out result);
    Console.WriteLine(result); // "123"
    decimal result;
    GetParsedValueOrDefault("123.546", decimal.TryParse, out result);
    Console.WriteLine(result); // "123.456"
    decimal result;
    GetParsedValueOrDefault("invalid", decimal.TryParse, out result);
    Console.WriteLine(result); // "0.0"
