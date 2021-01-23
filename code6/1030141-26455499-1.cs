    public class Job
    {
        //job
        public int JobId { get; set; }
        public int? JobNumber { get; set; }
        public string JobName { get; set; }
    
        [ForeignKey("CustomerPMId")] 
        public CustomerEmployee CustomerPM { get; set; }
        [ForeignKey("CustomerSuperintendentId")]        
        public CustomerEmployee CustomerSuperintendent { get; set; }
    }
