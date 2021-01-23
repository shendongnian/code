    private static void Main(string[] args)
    {
        var sendResult = send(options.FileName, options.Url).Result;
        Console.WriteLine(sendResult);
    }
