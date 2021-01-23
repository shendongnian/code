    namespace AsyncTestCase.Driver
    {
        internal static class Program
        {
            private static void Main()
            {
                AsyncTestCase test = new AsyncTestCase();
                string content = test.GetContent("http://www.google.com");
            }
        }
    }
