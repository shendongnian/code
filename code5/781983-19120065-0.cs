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
 
        public virtual Base Clone() { return new Base(this); }
    }
    public Child : Base
    {
        protected int field3;
       
        public Child () : base() { ... }
        
        protected Child (Child  copyThis) : base(copyThis)
        {
            this.field3 = copyThis.field3;
        }
        public override Base Clone() { return new A(this); }
    }
