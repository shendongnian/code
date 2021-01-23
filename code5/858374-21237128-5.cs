    public sealed class Parent
    {
        public Parent(string id, string name, IEnumerable<ChildBase> children)
        {
            Id = id;
            Name = name;
            //Children = children.Select(c => new Child(c.id, c.Name, this));
            Children = children.Select(c => new Child(c, this));
        }
    
        public string Id { get; private set; }
        public string Name { get; private set; }
    
        public IEnumerable<Child> Children { get; private set; }
    }
