        class BaseCS
        {
            private string name;
    
            public virtual string Name
            {
                get { return name; }
                set { name = "Base " + value; }
            }
    
        }
    
        class DerivedCS : BaseCS
        {
            public override string Name
            {
                set { base.Name = "Der " + value; }
                get { return base.Name; }
            }
        }
