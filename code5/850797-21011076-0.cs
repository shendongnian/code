    public class Parent : IParent
    {
        public IChild Child { get; set; }
        public Parent(IChild child)
        {
            child.Parent = this;
            this.Child = child;
        }
    }
    public class Child : IChild
    {
        public IParent Parent { get; set; }
    }
