    class Employee
    {
        public string Name { get; set; }
        public Employee Supervisor { get; set; }
        public List<Employee> Subordinates { get; set; }
    }
