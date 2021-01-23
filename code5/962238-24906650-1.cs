    public enum TestEnum
    {
        test1 = 1,
        test2 = 2,
        test3 = 3,
        test4 = 4
    }
    public class TestEnumClass
    {
        [Key]
        public int id { get; set; }
        [Range(1, int.MaxValue), Display(Name = "Test Enum")]
        public TestEnum test{ get; set; }
    }
