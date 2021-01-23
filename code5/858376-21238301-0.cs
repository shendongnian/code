    public sealed class Parent
    {
        private readonly IEnumerable<Child> children;
        private readonly string name; // Just for example
        public Parent(XElement element)
        {
             name = (string) element.Attribute("name");
             children = element.Elements("Child")
                               .Select(x => new Child(x, this))
                               .ToImmutableList(); // Or whatever collection you want
        }
    }
    public sealed class Child
    {
        private readonly Parent parent;
        private readonly string name; // Just for example
        public Child(XElement element, Parent parent)
        {
            this.name = (string) element.Attribute("name");
            // Better not ask the parent for its children yet - they won't be
            // initialized!
            this.parent = parent;
        }
    }
