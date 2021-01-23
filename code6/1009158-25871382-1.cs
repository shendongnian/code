    class Derived : Base
    {
        private readonly IDep dep;
        public Derived(IDep dep) : base(dep)
        {
            this.dep = dep;
        }
    }
