    class BaseClass
    {
        public void Write()
        {
            Method();
        }
        protected virtual void Method()
        {
            Console.WriteLine("Base - Method");
        }
    }
    class DerivedClass : BaseClass
    {
        private void CompletelyDifferentName()
        {
            Console.WriteLine("Derived - Method");
        }
    }
