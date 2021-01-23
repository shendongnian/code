    public class Person
    {
        public virtual int ItemId { get; set;}
        public virtual IList<EmailClass> Emails { get; set; } // plural Emails
    }
    public class EmailClass 
    {
        ...
        public virtual Person Person { get; set; } // inverse mapping
    }
