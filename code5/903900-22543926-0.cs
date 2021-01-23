    public class Parent
    {
        private IList<Child> _children = new List<Child>();
        public Parent() {} // probably don't want to hide default ctor
        
        public Parent(Child c)
        {
            AddChild(c);
        }
        public Parent AddChild(Child c)
        {
            c.Parent = this;
            _children.Add(c);
            return this;
        }
        public IList<Child> Children { get { return _children; } }
    }
    public class Child
    {
        public Parent Parent { get; set; }
    }
