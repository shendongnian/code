    // class C1 implements interface I1
    interface I1
    {
        void M1();
    }
    class C1 : I1
    {
        public void M1() { Console.WriteLine("C1.M1"); }
    }
    // class C2 implements interface I2
    interface I2
    {
        void M2();
    }
    class C2 : I2
    {
        public void M2() { Console.WriteLine("C2.M2"); }
    }
    // class C reuses C1 and C2
    // it implements I1 and I2 and delegates them accordingly
    class C: I1, I2
    {
        C1 c1;
        C2 c2;
        void I1.M1() { c1.M1(); }
        void I2.M2() { c2.M2(); }
    }
