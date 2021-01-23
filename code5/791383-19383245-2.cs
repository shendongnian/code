    public void PrintType<T>(T source)
    {
        Console.WriteLine(source.GetType());
    }
    int number = 23;
    string text = "Hello";
    
    PrintType(number);
    PrintType(text);
