    Class A
    {
        public static  A instance;
    
        static A()
        {
            if(condition)
            {
                instance = new B();
            }
            else
            {
                instance = new A();
            }
    
        }
    
        public A()
        {
            WriteSomething();
        }
    
        public static void WriteSomething()
        {
            Console.WriteLine("A constructor called");
        }
    
    }
    
    
    Class B : A
    {
        public B()
        {
            WriteSomething();
        }
    
        public static new void WriteSomething()
        {
            Console.WriteLine("B constructor called");
        }
    
    }
