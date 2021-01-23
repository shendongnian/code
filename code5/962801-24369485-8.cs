    public class Child
    {
        public Child(Int32 childId, Int32 rootId)
        {
            this.Child_Id = childId;
            this.Root_Id = rootId; 
        }
        public Int32 Child_Id { get; private set; }
        public Int32 Root_Id { get; private set; }
    }
    public class Root
    {
        public Root(IEnumerable<Child> children, IEnumerable<GrandChild> grandChildren )
        { 
            this.Children = new List<Child>(children);
            this.GrandChildren = new List<GrandChild>(grandChildren );
        }
        public ICollection<Child> Children { get; private set; }
        public ICollection<GrandChild> GrandChildren{ get; private set; }
    }
