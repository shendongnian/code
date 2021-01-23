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
                Console.WriteLine(((A)b).M());
            }
        }
    
        class A
        {
            public virtual A M()
            {
                return new A();
            }
        }
    
        class B : A 
        {
            public B M()
            {
                return new B();
            }
        }
    }
