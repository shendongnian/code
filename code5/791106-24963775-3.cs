    public class Person
    {
        public int PersonId { get; set; }
        public virtual User User { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
