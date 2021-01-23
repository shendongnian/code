    public class Job
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int64 JobId { get; set; }
    
        public int CustomerEmployeeAccountantId { get; set; }
        public virtual CustomerEmployee CustomerEmployeeAccountant { get; set;}
    }
