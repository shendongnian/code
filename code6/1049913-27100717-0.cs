        private static void Main(string[] args)
        {
            new Task(StartDoingNothing).Start();
            Console.WriteLine("test");
            Console.Read();
        }
        private static void StartDoingNothing()
        {
            for (var i = 0; i < 5000; i++)
            {
                //do something
            }
            Console.WriteLine("leaved");
        }
