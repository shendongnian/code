    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }
    }
