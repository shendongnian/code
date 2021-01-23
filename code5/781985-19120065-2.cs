    public abstract Base
    {
        protected int field1;
        protected int field2;
     
        protected Base() { ... }
        protected Base(Base copyThis) : this()
        { 
            this.field1 = copyThis.field1;
            this.field2 = copyThis.field2;
        }
 
        public abstract Base Clone();
    }
    public Child1 : Base
    {
        protected int field3;
       
        public Child1 () : base() { ... }
        
        protected Child1 (Child1  copyThis) : base(copyThis)
        {
            this.field3 = copyThis.field3;
        }
        public override Base Clone() { return new Child1(this); }
    }
    public Child2 : Base
    {
        public Child2 () : base() { ... }
        
        protected Child (Child  copyThis) : base(copyThis)
        {  }
        public override Base Clone() { return new Child2(this); }
    }
