    public partial class Employee
    {
        public Employee()
        {
    
        }
    
        public System.Guid EmployeeUUID { get; set; }
    
        public string SSN { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public System.DateTime ? CreateDate { get; set; }
        public System.DateTime HireDate { get; set; }
    
    }
