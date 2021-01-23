    public class Employee
    {
        [Required]
        public string LastName { get; set; }
    
        public string MiddleName { get; set; }
    
        [Required]
        public string FirstName { get; set; }
    
        public string Salary { get; set; }
        public double? SalaryAmount 
        { get
           {
              if (string.IsNullOrEmpty(Salary)) return null;
              return double.parse(Salary);
           }
         ]
    }
