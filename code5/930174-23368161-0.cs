        [Table("employee.email_manager")]
        public partial class email_manager
        {
            [Key]
            public int email_id { get; set; }
            public int employee_id { get; set; }
            [Required]
            [StringLength(255)]
            public string email { get; set; }
            public int email_type { get; set; }
            [Column(TypeName = "date")]
            public DateTime date_added { get; set; }
            public bool deleted { get; set; }
            [ForeignKey("email_type")]
            public virtual email_types email_types { get; set; }
            public virtual employees1 employees1 { get; set; }
        }
        [Table("employee.email_types")]
        public partial class email_types
        {
            public email_types()
            {
                email_manager = new HashSet<email_manager>();
            }
            [Key]
            public int email_type_id { get; set; }
            [Required]
            [StringLength(50)]
            public string email_type_name { get; set; }
            public virtual ICollection<email_manager> email_manager { get; set; }
        }
