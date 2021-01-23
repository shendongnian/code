    public class MyException : Exception
    {
        public MyException(TestClass testClass)
        {
            TestClass = testClass;
        }
        public TestClass TestClass { get; set; }
    }
