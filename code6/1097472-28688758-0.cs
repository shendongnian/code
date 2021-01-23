     class Program
        {
            static void Main(string[] args)
            {
    
                Task t1 = new Task(() => TaskOneWork());
                Task t2 = t1.ContinueWith((t) => TaskTwoWork());
                t1.Start();
                t2.Wait();
            }
    
            private static void TaskOneWork()
            {
                for(int i = 0 ; i < 1000000; i++)
                { }
            }
    
            private static void TaskTwoWork()
            {
                for (int i = 0; i < 1000000; i++)
                { }
            }
        }
