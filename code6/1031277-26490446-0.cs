    public class Parent : IParent
    {
        private Child _child;
        public int ParentId { get; set; }
        public IChild Child
        {
            get { return _child; }
            set { _child = (Child)value; } //dangerous zone
        }
    }
    public class Child : IChild
    {
        private Parent _parent;
        public int ChildId { get; set; }
        public IParent Parent
        {
            get { return _parent; }
            set { _parent = (Parent)value; } //dangerous zone
        }
    }
