    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Environment=" + Environment.CurrentDirectory);
                Console.WriteLine("Assembly=" + Assembly.GetExecutingAssembly().Location);
            }
        }
    }
