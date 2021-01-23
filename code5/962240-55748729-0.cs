    public class TestEnumClass
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Required"), Display(Name = "Test Enum")]
        public TestEnum? test{ get; set; }
    }
