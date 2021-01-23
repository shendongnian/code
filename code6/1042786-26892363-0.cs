    class Program {
        static void Main(string[] args) {
            TestClass test1 = new TestClass() {
                SomeInt = 1
            };
            Console.WriteLine(test1.SomeInt); // outputs 1
            TestClass test2 = test1;
            test2.SomeInt = 2;
            Console.WriteLine(test1.SomeInt); // ouputs 2
            TestClass test3 = new TestClass();
            test3.SomeInt = test1.SomeInt;
            test3.SomeInt = 4;
            Console.WriteLine(test1.SomeInt); // ouputs 2 still
            Console.ReadLine();            
        }
    }
    public class TestClass {
        public int SomeInt { get; set; }
    }
