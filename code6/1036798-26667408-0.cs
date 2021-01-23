    class ParentClass
    {
        public ParentClass() 
        {
             this.child = new ChildClass(this);
        }
        public ChildClass child { get; set; }
        class ChildClass
        {
            private ParentClass parent;
            public ChildClass(ParentClass par)
            {
                this.parent = parent;
            }
        }
    }
