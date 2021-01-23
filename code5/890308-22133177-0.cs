    class Program {
        static object lockObj = new object();
        static void Main(string[] args) {
            Console.WriteLine("Program starts running on thread {0}",
                Thread.CurrentThread.ManagedThreadId);
            var taskToRun = new Task(() => {
                lock (lockObj) {
                    for (int i = 0; i < 10; i++)
                        Console.WriteLine("{0} from Thread {1}",
                            i, Thread.CurrentThread.ManagedThreadId);
                }
            });
            lock (lockObj) {
                taskToRun.Start();
                taskToRun.Wait();
            }
        }
    }
