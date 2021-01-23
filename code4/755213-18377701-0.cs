    class A
    {
        protected virtual void f1()
        {
            Console.WriteLine("A");
        }
    }
    class A1 : A
    {
        public void f2()
        {
           //Simple Calling - prints `A1`
            f1();
           //Calling using base pointer - prints `A`
            base.f1();
        }
        protected override void f1()
        {
            Console.WriteLine("A1");
        }
    }
