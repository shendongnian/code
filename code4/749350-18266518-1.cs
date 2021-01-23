    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual Reviewer Reviewer { get; set; }
    }
    public class Reviewer
    {
        [Key]
        public int ReviewerId { get; set; }
        public virtual User User { get; set; }
    }
