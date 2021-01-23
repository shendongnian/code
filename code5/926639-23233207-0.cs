    class Program
    {
        static void Main(string[] args)
        {
            Thread thread2 = new Thread(new ThreadStart(Gone));
            thread2.Start();
            Console.Read();
        }
        static void Gone()
        {
            for (int i = 0; i < 5; i++)
            {
            
                Thread thread1 = new Thread(new ThreadStart(Going));
                thread1.Start();
                thread1.Join();
                Console.WriteLine("Gone");
            }
        }
        static void Going()
        {
            for (int i = 0; i < 2; i++)
            {       
                Console.WriteLine("Going");
            }
        }
