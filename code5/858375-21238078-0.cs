     class Program
        {
    
            public sealed class Child
            {
                private readonly Func<Parent> _getParent;
    
                public Child(string id, string name, Func<Parent> getParent)
                {
                    Id = id;
                    Name = name;
                    _getParent = getParent;
                }
    
                public Parent ParentInstance { get { return _getParent(); } }
                public string Id { get; private set; }
                public string Name { get; private set; }
            }
    
            public sealed class Parent
            {
                public Parent(string id, string name, IEnumerable<Child> children)
                {
                    Id = id;
                    Name = name;
                    Children = children;
                }
    
                public string Id { get; private set; }
                public string Name { get; private set; }
                public IEnumerable<Child> Children { get; private set; }
            }
            
            static void Main(string[] args)
            {
                Parent parent = null;
                Func<Parent> getParent = () => { return parent; };
                
                parent = new Parent("0", "Parent", new[] {new Child("0", "Child1", getParent), new Child("1", "Child1", getParent)});
    
                Console.WriteLine(parent.Children.First().ParentInstance.Name);
    
            }
        }
