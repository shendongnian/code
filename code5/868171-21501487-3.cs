    public class CustomerModel : IBirthable
    {
        public DateTime BirthDate { get; set; }
        public string BirthdayMessage { get; set; }
    }
    
    public class AnotherModel : IBirthable
    {
        public DateTime BirthDate { get; set; }
        public string BirthdayMessage { get; set; }
    }
