    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public virtual Collection<TimeCard> TimeCards { get; set; }
    
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
