    public class Company
    {
        public virtual String Id { get; set; }
        public virtual ICollection<Employee> Employees { get; protected set; }
        public Company()
        {
            Employees = new List<Employee>();
        }
        public void AddEmployee(Employee employee)
        {
            if (Employees.Contains(employee))
                return;
            Employees.Add(employee);
            employee.Company = this;
        }
        public void RemoveEmployee(Employee employee)
        {
            if (!Employees.Contains(employee))
                return;
            Employees.Remove(employee);
        }
    }
    public class Employee
    {
        public virtual String Id { get; set; }
        public virtual String FullName { get; set; }
        public virtual Company Company { get; set; }
    }
