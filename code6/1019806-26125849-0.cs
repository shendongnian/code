    class A
    {
        public static int s;
        A() { }
        static A() { s = 100; }
    }
    class B
    {
        public static int s = 100;
        B() { }
    }
