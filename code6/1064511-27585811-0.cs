    class Program
    {
        static void Main()
        {
            CallConstructorA();
            CallConstructorB();
        }
        static void CallConstructorA()
        {
            GC.KeepAlive(new C());
        }
        static void CallConstructorB()
        {
            GC.KeepAlive(new C(1));
        }
    }
    class C
    {
        public C() { }
        public C(int i)
        {
            GC.KeepAlive(i);
        }
    }
