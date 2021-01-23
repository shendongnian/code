    public sealed class Request {
        [XmlAttribute("ID")]
        public int Id { get; set; }
        [XmlAttribute("Status")]
        public string Status { get; set; }
        public DateTime TimeOffDate { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public decimal TimeOffHours { get; set; }
        public string TimeOffTypeName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginID { get; set; }
        public string Comment { get; set; }
    }
