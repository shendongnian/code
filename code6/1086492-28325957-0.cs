    public class App
    {
        public int AppID { get; set; }
        public string Business { get; set; }
        public string ApName { get; set; }
        public string FirstContact { get; set; }
        
        [ForeignKey("Colleague")]
        public int ColleagueId { get; set; }
        public virtual Colleague Colleague { get; set; }
    }
