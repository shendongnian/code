    class TestClass
    {
        private static TestClass DummyInstance;
        
        public static Action GetShowAsDelegate()
        {
            DummyInstance = DummyInstance ?? new TestClass();
            return (DummyInstance.Show);
        }
        public void Show()
        {
            Console.WriteLine("It works!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var show = TestClass.GetShowAsDelegate();
            show();
        }
    }
