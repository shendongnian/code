    class Program
    {
        static void Main(string[] args)
        {
            bool baseFeature1a = new Base1().Feature1; // false
            bool baseFeature1b = (new Derived1() as Base1).Feature1; // true
            bool baseFeature2a = new Base1().Feature2; // false
            bool baseFeature2b = (new Derived1() as Base1).Feature2; // true
        }
    }
    
    class Base1
    {
        private bool feature2 = false;
    
        public virtual bool Feature1
        {
            get { return false; }
        }
    
        public virtual bool Feature2
        {
            get { return feature2; }
            protected set { feature2 = value; }
        }
    }
    
    class Derived1 : Base1
    {
        public Derived1()
        {
            Feature2 = true;
        }
    
        public override bool Feature1
        {
            get { return true; }
        }
    }
