    public class Parent
    {    
        public int ParentID {get;set;}
        public virtual ICollection<Child> Children {get;set;}
    }
    public class Child 
    {    
        public int ChildID {get;set;}
        public virtual ICollection<Parent> Parents {get;set;}
    }
