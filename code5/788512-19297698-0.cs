    public class Parent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Child> Children { get; set; }
    }
