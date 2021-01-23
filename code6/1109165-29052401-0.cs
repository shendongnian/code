    public class Head
    {
        public int Id { get; set; }
        public virtual ICollection<Line> Lines { get; set; }
    }
