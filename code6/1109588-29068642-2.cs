    class Program
    {
        const string interpolated = $"{firstName}"; // Name does not exist
                                                    // in the current context
        static void Main(string[] args)
        {
            var firstName = "fred";
            Console.WriteLine(interpolated);
            Console.ReadKey();
        }
    }
