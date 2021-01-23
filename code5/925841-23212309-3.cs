    namespace ClassTest
    {
    
        class OuterClass
        {
            private class InnerClass
            {
            }
    
            OuterClass()
            {
                InnerClass Test = new InnerClass();
            }
    
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                OuterClass TestOne = new OuterClass();
                InnerClass TestTwo = new InnerClass(); // does not compile
            }
        }
    }
