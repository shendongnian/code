    class Program
    {
        public static async Task Test1()
        {
            await Task.Delay(1000);
            Console.WriteLine("Test1 is about to finish");
        }
        static void Main(string[] args)
        {
            var taskOuter = new Task<Task>(Test1);
            var taskInner = taskOuter.Unwrap();
                
            Task.Run(() =>
            {
                Thread.Sleep(2000);
                // run synchronously
                taskOuter.RunSynchronously();
                // or schedule
                // taskOuter.Start(TaskScheduler.Defaut);
            });
            taskInner.Wait();
            Console.WriteLine("Enter to exit");
            Console.ReadLine();
        }
    }
