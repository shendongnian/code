    class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(Work);
            thread.Start();
            Thread.Sleep(3000);
            thread.Abort();
        }
    
        static void Work()
        {
            try
            {
                while (true)
                {
                    // do work here
                }
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine(ex.StackTrace);
                // TODO: pass ex.StackTrace to main thread
            }
        }
    }
