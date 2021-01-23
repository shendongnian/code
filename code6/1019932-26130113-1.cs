    class Base
    {
        public string GetName()
        {
            return GetNameInternal() + "XX";
        }
        
        protected virtual string GetNameInternal() 
        {
            return "BaseName";
        }
    }
    
    class Derived1 : Base
    {
        protected override string GetNameInternal()
        {
            return "Derived1";
        }
    }
    
    class Derived2 : Base
    {
        protected override string GetNameInternal()
        {
            return "Derived2";
        }
    }
