    public class Employee
    {
        public List<Employee> ChildOrg { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public Employee(string id, string name)
        {
            Id = id;
            Name = name;
            ChildOrg = new List<Employee>();
        }
        public Employee AddChildOrg(string id, string name)
        {
            var newEmployee = new Employee(id, name);
            ChildOrg.Add(newEmployee);
            return newEmployee;
        }
        public static Employee GetNode(Employee father, string id)
        {
            if (father != null)
            {
                if (father.Id.Equals(id))
                    return father;
            
                if (father.ChildOrg != null)
                    foreach (var child in father.ChildOrg)
                    {
                        if (child.Id.Equals(id))
                            return child;
                        var employee = Employee.GetNode(child, id);
                        if (employee != null)
                            return employee;
                    }
            }
            return null;
        }
    }
