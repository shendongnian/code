    public Base
    {
        protected int field1;
        protected int field2;
        ....
        protected Base() { ... }
        public virtual Base Clone() 
        { 
            var bc = CreateInstanceForClone();
            bc.field1 = 1;
            bc.field2 = 2;
            return bc;
        }
        protected virtual Base CreateInstanceForClone()
        {
            return new Base(); 
        }
    }
    public A : Base 
    {     
        protected int fieldInA;
        public virtual Base Clone() 
        { 
            var a = (A)base.Clone();
            a.fieldInA =5;
            return a;
        }
        protected virtual Base CreateInstanceForClone()
        {
            return new A(); 
        }
    }
