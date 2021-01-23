    public delegate void TestHandler();
    static class Program
    {
        public static event TestHandler TestEvent;
        public static event TestHandler TestEvent1;
        public static event TestHandler TestEvent2;
    }
