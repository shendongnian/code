    public class Db
    {
        public Db(IEnumerable<Root> roots)
            {  this.Roots = new List<Root>(roots); }
    
        public ICollection<Root> Roots { get; private set; }
    }
    
    public class Root
    {
        public Root(IEnumerable<Child> children )
        { 
            this.Children = new List<Child>(children);
        }
    
        public ICollection<Child> Children { get; private set; }
    }
    
    
    public class Child
    {
        public Child(Int32 childId, Int32 rootId, IEnumerable<GrandChild> grandChildren)
        {
            this.Child_Id = childId;
            this.Root_Id = rootId; 
            this.GrandChildren = new List<GrandChild>(grandChildren);
        }
    
        public Int32 Child_Id { get; private set; }
        public Int32 Root_Id { get; private set; }
        public ICollection<GrandChild> GrandChildren {get; private set;}
    }
    
    public class GrandChild
    {
        public GrandChild (Int32 grandChildId, Int32 childId)
        { 
            this.GrandChild_Id = grandChildId; 
            this.Child_Id = childId; 
        }
    
        public Int32 GrandChild_Id {get; private set;}
        public Int32 Child_Id {get; private set;}
    }
