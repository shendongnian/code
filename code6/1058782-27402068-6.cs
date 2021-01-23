    class Derived
    {
        protected Base fBase;
    
        public Derived()
        {
            fBase = new Base;
        }
    
        //implement enything that you need to access from Base class
    
        public int Prop { get { return 1; } }
    }
