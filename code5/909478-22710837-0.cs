    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                testTask();
            }
            Console.Read();
        }
        private static void testTask()
        {
            int count = 0;
            Task t1 = new Task(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    count++;
                    //Console.WriteLine("Thread 1 - {0}", count);
                }
            }
           );
            Task t2 = new Task(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    count++;
                    //Console.WriteLine("Thread 2 - {0}", count);
                }
            }
          );
            t1.Start();
            t2.Start();
            Task.WaitAll(t1, t2);
            Console.WriteLine("Count - {0}", count);
        }
    }
