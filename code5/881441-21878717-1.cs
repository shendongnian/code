    public class User
    {
        public int Id { get; set; }
        public virtual User AddedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
    }
