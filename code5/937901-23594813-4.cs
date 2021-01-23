    public class Employee
    {
        #region Constructors
        public Employee()
        {
            Employees = new List<Employee>();
        }
    
        public Employee(string name) : this()
        {
            Name = name;
        }
    
        public Employee(string name, Employee manager) : this(name)
        {
            Manager = manager;
        }
    
        public Employee(string name, Employee manager, params Employee[] employees) : this(name, manager)
        {
            Employees.AddRange(employees);
        }
        #endregion
    
        #region Properties
        public List<Employee> Employees { get; set; }
        public int Id { get; set; }
        public Employee Manager { get; set; }
        public string Name { get; set; }
        #endregion
    }
