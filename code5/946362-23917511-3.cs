    class Program
    {
        private static event Action<int> MyEvent;
        public static void Main(string[] args)
        {
            Observable.FromEvent<int>(
                (handler) => Program.MyEvent += handler,
                (handler) => Program.MyEvent -= handler
                )
                .Subscribe(Console.WriteLine);
            Program.MyEvent(5);
            Console.ReadLine();
        }
    }
