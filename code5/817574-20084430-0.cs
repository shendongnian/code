    class B
    {
        A a = new A();
        public void CallFoo(object x)
        {
            if (x.GetType() == typeof(B))
            {
                a.Foo((B)x);
            }
            else
            {
                a.Foo(x);
            }            
        }
        public static void Main()
        {
            B b = new B();
            b.CallFoo(b);
            b.a.Foo(b);
        }
    }
