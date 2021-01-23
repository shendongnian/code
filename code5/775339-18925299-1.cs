    public static async Task Foo()
    {
        string result = await GetData("http://google.com", "");
        Console.WriteLine(result);
    }
