    public void Test()
    {
        Console.WriteLine(Parse<int>("1"));
        Console.WriteLine(Parse<decimal>("2"));
        Console.WriteLine(Parse<DateTime>("2015-04-20"));
    }
    public T Parse<T>(string input) { return (T)Convert.ChangeType(input, typeof(T), CultureInfo.InvariantCulture); }
