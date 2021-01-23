        static void Main(string[] args)
        {
            int TimeOut = (int)TimeSpan.FromMinutes(2).TotalMilliseconds;
            System.Threading.ManualResetEvent mreDuration = new System.Threading.ManualResetEvent(false);
            Task.Run(() => {
                System.Threading.Thread.Sleep((int)TimeSpan.FromMinutes(30).TotalMilliseconds);
                mreDuration.Set();
            });
            while(!mreDuration.WaitOne(TimeOut))
            {
                Console.WriteLine("Two Minutes...");
            }
            Console.WriteLine("Thirty Mintues!");
            Console.ReadLine();
        }
