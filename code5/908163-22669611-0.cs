    class A 
    {
        public abstract Func1();
    }
    class B : A
    {
        public override Func1()
        {
            MessageBox.Show("Hello World");
        }
    }
    class C : A
    {
        public override Func1()
        {
            MessageBox.Show("Goodbye World");
        }
    }
