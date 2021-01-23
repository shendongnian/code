    class ParentClass
    {
        public ParentClass() 
        {
             this.child = new ChildClass(this);
        }
        public ChildClass child { get; set; }
        class ChildClass
        {
            public ParentClass Parent { get; set; }
            public ChildClass(ParentClass par)
            {
                this.Parent = parent;
            }
        }
    }
