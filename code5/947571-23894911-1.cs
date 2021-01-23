    [Table("ReportDescription")]
    public class ReportDescription
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        public virtual CrimeReport CrimeReport { get; set; }
    }
