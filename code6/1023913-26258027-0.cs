    interface ISampleInterface
    {
        void Method();
    }
    class A : ISampleInterface
    {
        public void Method()
        {
        }
    }
    class B : A, ISampleInterface
    {
        void ISampleInterface.Method()
        {
        }
    }
    class C : A, ISampleInterface
    {
        public new void Method()
        {
        }
    }
