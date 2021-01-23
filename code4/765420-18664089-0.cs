    static class Program
    {
        static AutoResetEvent autoEvent = new AutoResetEvent(false);
        static void Main()
        {
            new Thread(ProcessKiller).Start();
            autoEvent.WaitOne(Timeout.Infinite);
        }
        static void ProcessKiller()
        {
            Console.WriteLine("Done");          
            //autoEvent.Set();
        }
    }
