    class Derived2 : Base
    {
        string name;
    
        public override string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    
        public override void DoWork()
        {
            this.Name = base.Name + " - Derived 2 did some work.....";
        } 
    }
