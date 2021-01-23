    class Test
        {
            static void Main(string[] args)
            {
                Consumer c = new Consumer();
                Task t = Task.Factory.StartNew(c.Consume);
    
                c.Queue();
                c.Queue();
                c.Queue();
                c.Queue();
                c.Queue();
    
                Thread.Sleep(1000);
                Console.ReadLine();
            }
        }
