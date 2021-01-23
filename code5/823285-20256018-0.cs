    public class Person
    {
        [DisplayIf("IsActive", "This value is true.", "This value is false.")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
