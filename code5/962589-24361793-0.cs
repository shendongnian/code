    static class MainClass
    {
    
        public static A APro { get; private set; }
        public static B BPro { get; private set; }    
            
        static MainClass()
        {
            A = new A();
            B = new B();
        }
    }
    
    class A
    {
        internal A(){}
        public int ProA { get; set; }
    }
    class B
    {
        internal B(){}
        public int ProB { get; set; }
    }
