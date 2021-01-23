    public class Parent
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Child> Children { get; set; }
    }
    public class Child
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public int OtherId { get; set; }
        public bool Active { get; set; }
        public int ParentId [get;set;}
        [ForeignKey("ParentId")]
        public virtual Parent Parent { get; set; }
    }
