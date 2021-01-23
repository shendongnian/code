    class Program
    {
        private static string l = "Demo lock resource";
        static void Main()
        {
            lock (l)
            {
                Thread.Sleep(Timeout.Infinite);
            }
        }
    }
