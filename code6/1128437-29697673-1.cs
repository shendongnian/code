    public void Test()
    {
        Console.WriteLine(Parse<int>("1"));
        Console.WriteLine(Parse<decimal>("2"));
        Console.WriteLine(Parse<DateTime>("2015-04-20"));
    }
    public static T Parse<T>(string input)
    {
        TypeConverter foo = TypeDescriptor.GetConverter(typeof(T));
        return (T)(foo.ConvertFromInvariantString(input));
    }
