    public class Child
    {
        [Key, Column(Order = 1)]
        public string Id { get; set; }
    
        [Key, ForeignKey("Parent"), Column(Order = 2)]  // adding this line fixed things for me
        public string ParentId {get; set;}
    }
    
    public class Parent
    {
        [Key, Column(Order = 1)]
        public string Id { get; set; }
       
        ...
    
        public virtual ICollection<Child> Children{ get; set; }
    }
