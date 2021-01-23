     class BaseCS
        {
            private string name;
    
            public string Name
            {
                get { return name; }
            set { name = "Base " + value; }
        }
    }
    class DerivedCS : BaseCS
    {
        public new  string Name
        {
            set { base.Name = "Der " + value; }
            get { return base.Name; }
        }
    }
    now you should create the object as the derived type to get your expected result
    
         DerivedCS one = new DerivedCS();
