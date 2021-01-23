    class Derived : Base
    {
        public Derived()
        {
    
        }
    
        protected override void OnInitialize()
        {
            // you can access the baseclass dependency Instance in this override
            object depObject = this.DepProperty;
        }
    }
