    public class Link
    {
        public int ID { get; set; }
        public virtual Category Category { get; set; }
    }
    public class Category
    {
        public int ID { get; set; }
        public Category(){Links = new List<Link>}
        public virtual IList<Link> Links {get; set;}
    }
