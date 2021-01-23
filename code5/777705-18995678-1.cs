    class A { }
    class B : A { }
    class C 
    {
        private A a1, a2;
        public C()
        {
           a2 = new B();
           Console.WriteLine(a1.GetCompileTimeType()); // null but prints A
           Console.WriteLine(a2.GetCompileTimeType()); // actually a B but prints A
        }
    }
