      public class Structure
       {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public List<Structure> Children { get; set; }
    
        public int? ParentId { get; set; } //this must be nullable, since the root item has no parent!
    
        public int ChildCount 
        { 
          get
          {
              //might as well do this:
              return Children == null ? 0 : Children.Count();
          } 
        }
    
        public int Lft { get; set; }
    
        public int Rgt { get; set; }
    
       }
