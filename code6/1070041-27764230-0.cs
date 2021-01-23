    public class ParentChangedEventArgs : EventArgs
    {
        public Parent Parent { get; private set; }
        public Child Child { get; private set; }
        public ParentChangedEventArgs(Parent parent, Child child)
        {
            this.Parent = parent;
            this.Child = child;
        }
    }
    public class Parent
    {
        public static event EventHandler<ParentChangedEventArgs> ParentChanged; // Could be internal or protected.
        public static Parent Root = new Parent(); // SHOULDN'T THIS BE READONLY?
        private readonly List<Child> children = new List<Child>();
        public ReadOnlyCollection<Child> Children
        {
            get { return children.AsReadOnly(); }
        }
        public void AppendChild(Child child)
        {
            var oldParent = child.Parent;
            if (oldParent == this)
                return;
            oldParent.children.Remove(child);
            this.children.Add(child);
            if (ParentChanged != null)
                ParentChanged(oldParent, new ParentChangedEventArgs(this, child));
        }
        public void RemoveChild(Child child)
        {
            Root.AppendChild(child); // Removing a child means adding it to the root.
        }
    }
    public class Child : Parent
    {
        static Child()
        {
            Parent.ParentChanged += new EventHandler<ParentChangedEventArgs>(Parent_ChildChanged);
        }
        static void Parent_ChildChanged(object sender, ParentChangedEventArgs e)
        {
            var child = e.Child;
            child.Parent = e.Parent;
        }
        private Parent parent = Parent.Root;
        public Parent Parent
        {
            get { return this.parent; }
            private set { this.parent = value; }
        }
    }
