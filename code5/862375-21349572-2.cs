        static void Main(string[] args)
        {
            Task dbCheckerThread = new Task(CheckSomethingInDb);
            dbCheckerThread.Start();
            Console.WriteLine("... the application is running further..."); 
            Console.ReadKey();
        }
