    // quick and dirty class
    public class Employee
    {
        public int Id;
        public string Name;
        public int ParentId;
        public IList<Employee> Children = new List<Employee>();
        public override int GetHashCode()
        {
            return Id;
        }
        public override bool Equals(object obj)
        {
            Employee that;
            return
                obj != null
                && (that = obj as Employee) != null
                && Id == that.Id;
        }
    }
    // O(n) time, O(n) space for hashmap
    public Employee BuildTreeView(IEnumerable<Employee> employees)
    {
        var rootEmployee = new Employee() { Id = 0 };
        var IdToEmployeeMap = employees.ToDictionary(e => e.Id);
        foreach (var employee in employees)
        {
            var parentEmployee = employee.ParentId == 0 ? rootEmployee : IdToEmployeeMap[employee.ParentId];
            parentEmployee.Children.Add(employee);
        }
        return rootEmployee; // or return rootEmployee.Children if interested in children
    }
