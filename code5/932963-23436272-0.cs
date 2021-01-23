    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [ForeignKey("Store")]
        public int StoreNumber { get; set; }
        // Navigation Properties
        public virtual Store Store { get; set; }
    }
    public class Store
    {
        [Key]
        public int StoreNumber { get; set; }
        // Navigation Properties   
        public virtual List<Employee> Employees { get; set; }
    }
