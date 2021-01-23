    class A {}
    class B
    {
        public int i;
    }
    
    A a = new B();
    a.i = 0; // error
    ((B)a).i = 0; // OK
