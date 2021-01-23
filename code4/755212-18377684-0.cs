    class A
    {
        protected virtual void f1() {   }
    }
    class A1 : A
    {
        protected override void f1() {   }
        public void f2()
        {
           //Simple Calling
            f1();                 <--- this will call to overrided f1 in this class
           //Calling using base pointer
            base.f1();
        }
    }
