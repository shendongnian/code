    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
