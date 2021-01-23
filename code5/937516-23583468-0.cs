    class Employee
    {
        public int Id { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
    class Project
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
    }
    var employee = new Employee { Id = 1, Projects = new List<Project>
    {
        new Project { EmployeeId = 1, Name = "Foo" },
        new Project { EmployeeId = 1, Name = "Bar" }
    }};
