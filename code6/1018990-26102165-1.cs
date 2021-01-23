    public class A
    {
        void Print(string message)
        {
            Console.WriteLine("Hi!");
        }
    
        public A()
        {
            new B().Method1(Print);
        }
    }
    
    public class B
    {
        public void Method1(Action<string> PrintOutput)
        {
            new C().Method2(PrintOutput);
        }
    }
    
    public class C
    {
        public void Method2(Action<string> PrintOutput)
        {
            PrintOutput("Bye!");
        }
    }
