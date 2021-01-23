    class Base : IBase
    {
        string name = "Base Class: ";
    
        public virtual string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    
        public virtual void DoWork()
        {
            //Base class does no work...
        }
    }
