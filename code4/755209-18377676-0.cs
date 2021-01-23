    class A1 : A
    {
        public void f2()
        {
           //Simple Calling
            f1();
           //Calling using base pointer
            base.f1();
        }
        protected new void f1()
        {
            // I won't be called
        }
    }
