    public class Employee
    {
        ...
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }
    public class Department
    {
        ...
        public int DirectorID { get; set; }
        public Director Director { get; set; }
    }
