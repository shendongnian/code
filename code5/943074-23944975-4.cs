    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
    public class Blog
    {
        public int Id { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
