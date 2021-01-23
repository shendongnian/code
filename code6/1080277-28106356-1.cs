    public delegate void TestHandler();
    static class Program
    {
        // backing fields with the same names:
        private static TestHandler TestEvent;
        private static TestHandler TestEvent1;
        private static TestHandler TestEvent2;
        // each event is really a pair of two "methods" (accessors)
        public static event TestHandler TestEvent
        {
            add
            {
                // smart code to access the private field in a safe way,
                // combining parameter 'value' into that
            }
            remove
            {
                // smart code to access the private field in a safe way,
                // taking out parameter 'value' from that
            }
        }
        public static event TestHandler TestEvent1
        {
            add
            {
                // smart code to access the private field in a safe way,
                // combining parameter 'value' into that
            }
            remove
            {
                // smart code to access the private field in a safe way,
                // taking out parameter 'value' from that
            }
        }
        public static event TestHandler TestEvent2
        {
            add
            {
                // smart code to access the private field in a safe way,
                // combining parameter 'value' into that
            }
            remove
            {
                // smart code to access the private field in a safe way,
                // taking out parameter 'value' from that
            }
        }
    }
