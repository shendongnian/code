    class Program
        {
            [ThreadStatic]
            static int value = 10;
    
            static void Main(string[] args)
            {
                value = 25;
    
                Task t1 = Task.Run(() =>
                {
                    value++;
                    Console.WriteLine("T1: " + value);
                });
                Task t2 = Task.Run(() =>
                {
                    value++;
                    Console.WriteLine("T2: " + value);
                });
                Task t3 = Task.Run(() =>
                {
                    value++;
                    Console.WriteLine("T3: " + value);
                });
    
                Console.WriteLine("Main Thread : " + value);
    
                Task.WaitAll(t1, t2, t3);
                Console.ReadKey();
            }
        }
