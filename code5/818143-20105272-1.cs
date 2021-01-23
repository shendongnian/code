    class Skill
    {
        ...
        public virtual List<Employee> Employees { get; set; }
    }
    class Employee
    {
        ...
        public virtual List<Skill> Skills { get; set; }
    }
