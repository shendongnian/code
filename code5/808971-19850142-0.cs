    class Program
    {
        public static async Task Foo(int num)
        {
            Console.WriteLine("Thread {0} - Start {1}", Thread.CurrentThread.ManagedThreadId, num);
            var newTask = Task.Delay(1000);
            await newTask;
            Console.WriteLine("Thread {0} - End {1}", Thread.CurrentThread.ManagedThreadId, num);
            
        }
        public static List<Task> TaskList = new List<Task>();
        public static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                int idx = i;
                Task fooWrappedInTask = Task.Run(() => Foo(idx));
                TaskList.Add(fooWrappedInTask);
            }
            Task.WaitAll(TaskList.ToArray());
            Console.WriteLine("Finished waiting for all of the tasks: - Thread {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
