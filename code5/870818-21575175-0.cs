    class Program
    {
        static void Main(string[] args)
        {
            Thread poller = new Thread(new ThreadStart(PollUSBDevice));
            poller.Start();
            Console.ReadLine();
            StopPoller();
            Console.WriteLine("Stopped");
            Console.ReadLine();
        }
        public static void StopPoller()
        {
            _PollerStopRequested = true;
        }
        private static bool _PollerStopRequested = false;
        private static void PollUSBDevice()
        {
            while (true && !_PollerStopRequested)
            {
                Console.WriteLine("running");
                Thread.Sleep(500);
            }
        }
    }
