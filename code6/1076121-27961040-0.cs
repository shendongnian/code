    class Program
    {
        static void Main(string[] args)
        {
            ScheduleAction(DateTime.UtcNow.AddSeconds(4), Action1, "A", "B");
            ScheduleAction(DateTime.UtcNow.AddSeconds(8), Action1, "C", "D");
            ScheduleAction(DateTime.UtcNow.AddSeconds(12), Action1, "E", "F");
            Console.WriteLine("Running ...");
            Console.ReadLine();
        }
        private static void ScheduleAction(DateTime runOnceAt, Action<string, string> action, string param1, string param2)
        {
            FluentScheduler.TaskManager.AddTask(() =>
            {
                action.Invoke(param1, param2);
            }, x => x.WithName("MyTask").ToRunOnceAt(runOnceAt));
        }
        private static void Action1(string param1, string param2)
        {
            Console.WriteLine("Running Action 1 {0} - {1}", param1, param2);
        }
        private static void Action2(string param1, string param2)
        {
            Console.WriteLine("Running Action 2 {0} - {1}", param1, param2);
        }
        private static void Action3(string param1, string param2)
        {
            Console.WriteLine("Running Action 3 {0} - {1}", param1, param2);
        }
    }
