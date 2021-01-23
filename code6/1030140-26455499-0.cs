    public class Job
    {
        //job
        public int JobId { get; set; }
        public int? JobNumber { get; set; }
        public string JobName { get; set; }
    
        public CustomerEmployee CustomerPM { get; set; }
        public CustomerEmployee CustomerSuperintendent { get; set; }
    }
