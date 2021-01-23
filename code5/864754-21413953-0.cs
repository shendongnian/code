    static void Main(string[] args)
    {
        A<C, D> test = new A<C, D>();
        test.Call(new Cimpl(), new Dimpl());
    }
    class A<T1, T2> where T1 : C where T2 : D
    {
        public void Call(T1 arg1, T2 arg2)
        {
            B b = new B();
            b.DoSomething(arg1); // determine which overload to use based on T1
            b.DoSomething(arg2); // and T2
        }
    }
    class Cimpl : C { }
    class Dimpl : D { }
    interface C
    { }
    interface D
    { }
    class B
    {
        public void DoSomething(C x)
        {
            // ...
        }
        public void DoSomething(D x)
        {
            // ...
        }
    }
