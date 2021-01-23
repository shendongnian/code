    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            Thread thread = new Thread(() =>
            {
                while (!Volatile.Read(ref exit))
                {
                    Console.Error.Write('.');
                    Thread.Sleep(250);
                }
            });
            thread.Start();
            Console.ReadLine();
            Volatile.Write(ref exit, true);
            thread.Join();
        }
    }
