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
            if (result.IsDU1) Console.WriteLine("Is Int: " + ((test.DUForCSharp.DU1)result).Item);
            else Console.WriteLine("Is Not Int: " + ((test.DUForCSharp.DU2)result).Item);
        }
    }
