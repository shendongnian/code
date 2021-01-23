    class Base
    {
        public virtual int Prop { get; set; }
    }
    
    class Derived : Base
    {
        public override int Prop { get { return 1; } private set {}}
    }
