    class A {
       public B BReference { get; set; }
    }
    class B {
       public A AReference { get; set; }
    }
    static class Program 
    {
        [STAThread]
        public static void Main()
        {
            A a = new A();
            B b = new B();
            b.AReference = a;
            a.BReference = b;
            // you should have b.AReference == a and
            // a.Breference == b
        }
    }
