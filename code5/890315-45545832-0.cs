    class Program
    {
        static AutoResetEvent signalEvent = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                Console.WriteLine("Program starts running on thread {0}",
                     Thread.CurrentThread.ManagedThreadId);
                var taskToRun = new Task(() =>
                {
                    signalEvent.WaitOne();
                    for (int i = 0; i < 10; i++)
                        Console.WriteLine("{0} from Thread {1}", 
                            i, Thread.CurrentThread.ManagedThreadId);
                });
                taskToRun.Start();
                signalEvent.Set();
                taskToRun.Wait();
            }).Wait() ;
        }
    }
