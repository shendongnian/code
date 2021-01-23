        class A
        {
            public int x { get; set; }
        }
    
        class B
        {
            public int foo()
            {
                return 3;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                B data = new B();
                A a = new A() {
                    x = data.foo()
                };
            }
        }
