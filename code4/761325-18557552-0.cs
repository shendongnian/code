    namespace Streamtest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test cTest = new Test();
                cTest.Name = "Hello!";
    
                Do(cTest);
    
                Console.WriteLine(cTest.Name);
                Console.ReadLine();
            }
    
            static void Do(Test Test)
            {
                Test.Name = Test.Name + " " + Test.Name;
            }
        }
    
        public class Test
        {
            public string Name
            {
                get;
                set;
            }
        }
    }
