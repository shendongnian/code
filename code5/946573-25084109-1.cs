    public class Employee
    {
        [PrimaryKey]
        [MaxLength(36)]
        public string EmployeeGuid { get; set; }
        public string EmployeeName { get; set; }
        [OneToMany]
        public List<Employee> Subordinates { get; set; }
        [ManyToOne]
        public Employee Supervisor { get; set; }
        [ForeignKey(typeof(Employee))]
        [MaxLength(36)]
        public string SupervisorGuid { get; set; }
    }
