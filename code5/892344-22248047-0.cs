    public class Test
    {
        [Key]
        public long Id { get; set; }
    
        [Required]
        public string Title { get; set; }
        [Required]
        [ForeignKey("TestType")]
        public int TestTypeId { get; set; }
    
        [DisplayName("Test type")]
        public virtual TestType TestType { get; set; }
    }
    
    public class TestType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
