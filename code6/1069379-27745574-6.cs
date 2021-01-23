    class Program
    {
        static void Main(string[] args)
        {
            bool baseFeature1 = new Base1().Feature1; // false
            // the overriden Feature1 has precedence.
            bool baseFeature1b = (new Derived1() as Base1).Feature1; // true
        }
    }
    
    class Base1
    {
        public virtual bool Feature1
        {
            get { return false; }
        }
    }
    
    class Derived1 : Base1
    {
        public override bool Feature1
        {
            get { return true; }
        }
    }
