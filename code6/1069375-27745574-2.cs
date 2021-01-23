    class Program
    {
        static void Main(string[] args)
        {
            // This will throw an exception.
            new Derived1().Feature1 = false;
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
    }
    
    class Derived1 : Base1
    {
        public override bool Feature1
        {
            get { return true; }
            // Setter not overriden.
            //set { throw new InvalidOperationException("In this implementation 'Feature1' is read-only."); }
        }
    }
