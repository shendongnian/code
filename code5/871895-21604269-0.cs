    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to c#");
            // Example 1
            if (args.Count() > 0 && args[0].ToUpper().Equals("DOWNLOADPOS1"))
            {
                Console.WriteLine("Called via Arguments");
                DownloadPOS();
            }
            // Example 2
            else if ("DOWNLOADPOS2" == Console.ReadLine().ToUpper())
            {
                Console.WriteLine("Called via user input");
                DownloadPOS();
            }
            // To stop command prompt disappearing
            Console.ReadLine();
        }
        private static void DownloadPOS()
        {
            Console.WriteLine("Hello from DownloadPOS");
        }
    }
