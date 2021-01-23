    public class Employee
    {
        public Employee()
        {
            ChildOrg = new List<Employee>();
        }
        public Employee(string toString, string root)
        {
            ChildOrg = new List<Employee>();
            Id = toString;
            Name = root;
        }
        public IList<Employee> ChildOrg { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public static Employee GetNode(Employee e, string theId)
        {
            if (e.Id.Equals(theId))
            {
                return e;
            }
            var employeeInList = (e.ChildOrg == null) ? null : e.ChildOrg.FirstOrDefault(item => item.Id.Equals(theId));
            return employeeInList ??
                   e.ChildOrg.Select(item => GetNode(item, theId)).FirstOrDefault(employee => employee != null);
        }
    }
