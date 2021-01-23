    class Program
    {
        static void Main(string[] args)
        {
            // Compiler error. There is no setter.
            new Base1().Feature2 = false;
            // The derived class has a setter. No error.
            new Derived1().Feature2 = true;
        }
    }
    
    class Base1
    {
        private bool feature1;
        public virtual bool Feature1
        {
            get { return feature1; }
            set { feature1 = value; throw new Exception("You've set me anyway!"); }
        }
        public virtual bool Feature2
        {
            get { return false; }
        }
    }
    
    class Derived1 : Base1
    {
        bool feature2;
        public override bool Feature1
        {
            get { return true; }
            //set { throw new InvalidOperationException("In this implementation 'Feature1' is read-only."); }
        }
        public virtual bool Feature2
        {
            get { return feature2; }
            set { feature2 = value; }
        }
    }
