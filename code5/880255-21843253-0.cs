    public interface IMembershipPrincipal<T> where T:IEmail
    {
        int ID { get; set; }
        string UserName { get; set; }
        ICollection<T> Emails { get; set; }
    }
    public interface IEmail
    {
        string Address { get; set; }
        int UserID { get; set; }
    }
    public class User : IMembershipPrincipal<Email>
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
    }
    public class Email : IEmail
    {
        [Key]
        public string Address { get; set; }
        public int UserID { get; set; }
    }
