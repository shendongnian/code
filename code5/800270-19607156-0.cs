    class EventDemo
    {
        public static void Handler()
        {
            Console.WriteLine("Event occurred");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyEvent evt = new MyEvent();
            evt.SomeEvent += EventDemo.Handler;
            evt.OnSomeEvent();
        }
    }
