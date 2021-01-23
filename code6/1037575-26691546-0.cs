    public abstract class JobResult{
        [Key, ForeignKey("Job")]
    public int JobId { get; set; }
    [Required]
    public virtual Job Job { get; set; }
