    [Table("Risk")]
    public class Risk {
        [Key]
        [Column("RiskId")]
        public long Id { get; set; }
        //...
        [Column("CreatedBy")]
        public int? CreatedById { get; set; }  // or int if CreatedBy is required
        [ForeignKey("CreatedById")]
        public UserProfile CreatedBy { get; set; }
    }
