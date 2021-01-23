    public class DoSomeWork : IDoSomeWork
    {
        public void Execute()
        {
            Console.WriteLine("Starting");
            Thread.Sleep(500);
            Console.WriteLine("Done");
        }
    }
