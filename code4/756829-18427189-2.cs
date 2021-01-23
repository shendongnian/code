    class Program
    {
        static void Main(string[] args)
        {
            DoStuff(5000);
            Console.WriteLine("Here's the main thread.");
            Console.Read();
        }
        private static async void DoStuff(int delay = 0)
        {
            await Task.Delay(delay);
            Console.WriteLine("Task done!");
        }
    }
