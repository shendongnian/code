    class Program
    {
        static void Main(string[] args)
        {
            PrintToConsole("5");
            PrintToConsole("test");
        }
        static void PrintToConsole(string value)
        {
            var result = test.getResult(value);
            if (result.IsIntValue) Console.WriteLine("Is Int: " + ((test.DUForCSharp.IntValue)result).Item);
            else Console.WriteLine("Is Not Int: " + ((test.DUForCSharp.StringValue)result).Item);
        }
    }
