    public class Company
        {
            [Key]
            public int id { get; set; }
            [Required]
            public string name { get; set; }
        }
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string jobtitle { get; set; }
        [Required]
        public string number { get; set; }
        [Required]
        public string address { get; set; }
    }
    public class CompanyEmployee
    {
        public Company company { get; set; }
        public List<Employee> employees { get; set; }
    }
