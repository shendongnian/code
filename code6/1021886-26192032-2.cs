    public class Employee : IEmployee
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public virtual Collection<TimeCard> TimeCards { get; set; }
        ICollection<ITimeCard> IEmployee.TimeCards { get { return TimeCards; } }
    
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        IDepartment IEmployee.Department { get { return Department; } set { Department = value; } }
    }
