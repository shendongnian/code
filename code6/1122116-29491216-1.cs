    class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Departments
        {
            get 
            { 
               if (AssociatedDepartment == null || AssociatedDepartment.Count == 0)
                  return string.Empty;
               return string.Join(", ", AssociatedDepartment.Select(d => d.DepartmentName));
            }
        }
        public List<Department> AssociatedDepartment { get; set; }
    }
