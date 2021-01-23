    class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Departments
        {
            get { return string.Join(", ", AssociatedDepartment.Select(d => d.DepartmentName)); }
        }
        public List<Department> AssociatedDepartment { get; set; }
    }
