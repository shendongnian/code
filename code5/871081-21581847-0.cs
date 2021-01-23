    public static string ToStringOrEmpty<T>(this T? t) where T : struct
    {
        return t.HasValue ? t.Value.ToString() : string.Empty;
    }
    
    // usage
    int? a = null;
    long? b = 123;
    
    Console.WriteLine(a.ToStringOrEmpty()); // prints nothing
    Console.WriteLine(b.ToStringOrEmpty()); // prints "123"
