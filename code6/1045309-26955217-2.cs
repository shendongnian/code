    public class Parent
    {
        ...
        // correct mapping of the children
        public virtual IList<Child> Children{ get; set; } 
        // this method uses the below updated Child version
        public virtual void AddChild(Child ch)
        {
            // this is replaced
            // ch.IdParent = this.Id;
            // with this essential assignment
            ch.Parent = this;
            Children.Add(ch);
        }
     }
    public class Child
    {
        ...
        // instead of this        
        // public virtual int IdParent {get;set;} 
        // we need the reference expressed as object
        public virtual Parent Parent { get; set; } 
    }
