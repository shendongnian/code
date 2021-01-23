    class Program
    {
        private static string pathToFile;
        static int Main(string[] args)
        {
            if (args.Any()) pathToFile = args[0];
            if (args.Length>1) {Console.Error.WriteLine("Too many parameters");
                return 1;
            }
            while (string.IsNullOrWhiteSpace(pathToFile))
            {
                Console.Write("PathToFile is missing. Please provide PathToFile:");
                pathToFile = Console.ReadLine();
            }
            // And here you do something with PathToFile
        }
    }
