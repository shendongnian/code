    public class Conference
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OwnerName { get; set; }
        public List<DialNumber> DialInNumbers { get; set; }
    }
    public Class DialNumber
    {
        public string Number{get;set;}
        public int ConferenceId{get;set;}
        public Conference Conference{get;set;}
    }
