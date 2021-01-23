    namespace ConsoleApplication10
    {
        interface IA
        {
            void Print();
        }
    
        class A : IA
        {
            public void Print()
            {
                Console.WriteLine("Hello");
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                Type type = Type.GetType("ConsoleApplication10.A");
                type.GetMethod("Print").Invoke(Activator.CreateInstance(type, null), null);
            }
        }
    }
