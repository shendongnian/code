    public class Brief
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string tId {get; set;}
        public int SpeakerId { get; set; }
        //Navigational property
        public virtual Speaker Speaker { get; set;} 1 Brief has 1 Speaker
    }  
