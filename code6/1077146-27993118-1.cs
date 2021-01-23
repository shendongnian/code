    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                var a = new A();
                var b = new B();
    
                Console.WriteLine(a.M());
                Console.WriteLine(b.M());
            }
        }
    
        class A
        {
            public A M()
            {
                return (A)Activator.CreateInstance(GetType());
            }
        }
    
        class B : A 
        {
        }
    }
