    class Program
    {
        public static ManualResetEvent ServerManualResetEvent;
        static void Main(string[] args)
        {
            try
            {
                // your code to start the server
                ServerManualResetEvent.WaitOne();
            }
            catch
            {
                // your catch code
            }
        }
    }
