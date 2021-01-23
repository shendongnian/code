    public class EmployeeViewModel
    {
        public EmployeeViewModel(Employee employee, int level)
        {
            Employee = employee;
            Level = level;
        }
    
        public Employee Employee { get; set; }
        public int Level { get; set; }
    }
