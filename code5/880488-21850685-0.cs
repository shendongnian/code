    static void Main(string[] args)
    {
        Task<string> asyncValue = GetAsyncTimeFromWcf();
        Console.WriteLine("Waiting for server...");
        Console.WriteLine(String.Format("Result = {0}", asyncValue.Result);
        Console.ReadKey();
    }
