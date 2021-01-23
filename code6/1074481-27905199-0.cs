    [Table("StudentStatus")]
    public class StudentStatus
    {
        [Key]
        public int Id { get; set; }
    
        [Required(ErrorMessage = "Student status name is required")]
        [MaxLength(50, ErrorMessage = "Student status name cannot be longer than 50 characters")]
        public string Name { get; set; }
   
        [ForeignKey("StudentStatusType")] 
        public int StudentStatusTypeId { get; set; }
        public virtual StudentStatusType StudentStatusType { get; set; }
    }
    
    [Table("StudentStatusType")]
    public class StudentStatusType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
