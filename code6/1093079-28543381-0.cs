        static void Main(string[] args)
        {
            var console = new object();
            int i = 0;
            Task.Run(() =>
            {
                lock (console)
                    while (i++ < 10)
                    {
                        Console.Write(i);
                        Monitor.Pulse(console);
                        Monitor.Wait(console);
                    }
            });
            Task.Run(() =>
            {
                lock (console)
                    while (i < 10)
                    {
                        Console.Write('+');
                        Monitor.Pulse(console);
                        Monitor.Wait(console);
                    }
            });
            Console.ReadLine(); // Task.WaitAll might be better, remove for fiddle
        }
