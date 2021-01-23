    class Program
    {
        static void Main(string[] args)
        {
            ServerManager serverManager = new ServerManager();
            foreach (var site in serverManager.Sites)
            {
                Console.WriteLine("Site -> " + site.Name);
                foreach (var application in site.Applications)
                {
                    Console.WriteLine("  Application-> " + application.Path);
                }
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey(true);
        }
    }
