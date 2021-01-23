    public class Department
    {
        public int Id { get; set; }
        ...
        public ICollection<Employee> Employees { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        ...
        public ICollection<Department> Departments { get; set; }
    }
