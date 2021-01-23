    [Table("PbnJobs")]
    public abstract class PbnJob : Job
    {
        public virtual PbnSite Site{ get; set; }
        
        [ForeignKey("Site")]
        [Required]
        public int SiteId { get; set; }
    }
