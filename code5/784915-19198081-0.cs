    [DataContract]
    public class PostLine
    {
        ...
        public DateTime DateUtcAsDateTime { get; set; }
        [DataMember, NotMapped]
        public string DateUtcAsString {
            get { return DateUtcAsDateTime.ToString(); }
            set { DateUtcAsDateTime = DateTime.Parse(value); }
        }
        ...
    }
