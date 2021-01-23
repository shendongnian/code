    public class User
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public List<AvailabilityDates> Dates { get; set; }
    }
    public class AvailabilityDates
    {
        public DateTime? date { get; set; }
    }
