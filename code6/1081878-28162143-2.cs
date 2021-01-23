    static void Main(string[] args)
    {
    
        MyThreadSafeSortedSet queue = new MyThreadSafeSortedSet();
    
        var task1 = Task.Run(() =>
            {
                Random r = new Random();
                for (int i = 0; i < 15; i++)
                {
                    Task.Delay(100).Wait();
                    var randomNumber = r.Next();
                    queue.Add(randomNumber);
                }
                Console.WriteLine("I'm done adding");
            });
        var task2 = Task.Run(() =>
        {
            Random r = new Random();
            while (true)
            {
                var delay = r.Next(500);
                Task.Delay(delay).Wait();
    
                var item = queue.Take();
                Console.WriteLine("Took: {0}", item);
                if (item == null)
                    break;
            }
        });
    
        Task.WaitAll(task2);
    }
