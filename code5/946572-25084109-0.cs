    public class Employee
    {
        [PrimaryKey]
        [MaxLength(36)]
        public string EmployeeGuid { get; set; }
        public string EmployeeName { get; set; }
        [OneToMany(inverseProperty: "Supervisor")]
        public List<Employee> Subordinates { get; set; }
        [ManyToOne(inverseProperty: "Subordinates")]
        public Employee Supervisor { get; set; }
        [ForeignKey(typeof(Employee))]
        [MaxLength(36)]
        public string SupervisorGuid { get; set; }
    }
