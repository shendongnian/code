    public class DowntimeEventModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        public int LocationID { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<SystemModel> AffectedSystems { get; set; }
        public virtual ICollection<DepartmentModel> AffectedDepartments { get; set; }
    }
