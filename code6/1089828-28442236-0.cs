    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public int LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; }
    }
    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
