    public sealed class Child : ChildBase
    {
        public Child(string id, string name, Parent parent): base(Id, name)
        {
            Parent = parent;
        }
    
        public Parent ParentInstance { get; private set; }
    }
