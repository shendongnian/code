    class Base
    {
        public virtual int Prop { get; protected set; }
    }
    class Derived : Base
    {
        public override int Prop { 
            get { return 1; } 
            protected set {throw NotSupportedException();}  
        }
    }
