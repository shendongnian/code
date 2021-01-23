    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = null;
            if (args.Length > 0 && args[0].Length > 0)
            {
                inputFile = args[0];
            }
            else
            {
                Console.WriteLine("No command-line input detected. Please enter a filename:");
                inputFile = Console.ReadLine();
            }
            Console.WriteLine("Beginning Operation on file {0}", inputFile);
            /* Do Work Here */
        }
    }
