    public class WorkLogs
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkLogId { get; set; }
        [Required]
        public int Time { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public bool IsSent { get; set; }
        public int Users_UserId { get; set; }
        public int Works_WorkdId { get; set; }
        [ForeignKey("Users_UserId")]
        public virtual Users User { get; set; }
        [ForeignKey("Works_WorkdId")]
        public virtual Works Work { get; set; }
    }
