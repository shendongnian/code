    class Program
    {
        public static void CheckSomethingInDb()
        {
            while (true)
            {
                // do periodical check 
                Console.WriteLine("Periodical check"); 
                Thread.Sleep(500); 
            }
        }
        static void Main(string[] args)
        {
            var dbCheckerThread = new Thread(CheckSomethingInDb);
            dbCheckerThread.IsBackground = true;
            dbCheckerThread.Start();
            Console.WriteLine("... the application is running further..."); 
            Console.ReadKey();
        }
    }
