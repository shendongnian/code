    namespace ConsoleApplication1
    {
        public class TestClass1
        {
            public TestClass1()
            {
                Console.WriteLine("This is base class constructor1");
            }
       
            public TestClass1(string str1, string str2)
            {
                Console.WriteLine("This is base class constructor2");
            }
            public TestClass1(string str1, string str2, string str3)
            {
                Console.WriteLine("This is base class constructor3");
            }
            public TestClass1(string str1, string str2, string str3, string str4)
            {
                Console.WriteLine("This is base class constructor4");
            }
        }
        public class TestClass2 : TestClass1
        {
            public TestClass2(string str)
            {
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                TestClass2 test = new TestClass2("test");
                TestClass2 test1 = new TestClass2("test,test");
            
            }
        }
    }
