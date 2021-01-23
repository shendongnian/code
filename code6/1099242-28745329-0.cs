    public class Phone
    {
        public string Phone { get; set; }
    }
    public class Email
    {
        public string Email { get; set; }
    }
    public class Employee
    {
        ...
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
    }
