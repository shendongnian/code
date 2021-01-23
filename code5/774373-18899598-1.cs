    public class Data
    {
        public List<Employee> Employees { get; set; }
    }
    
    public class Employee
    {
        public List<EmpDetails> EmpDetailss { get; set; }
    }
    
    public class EmpDetails
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public string Empdept { get; set; }
        public EmpPhone EmpPhone{ get; set; }
    }
    public class EmpPhone
    {
        public string Home { get; set; }
        public string Office { get; set; }
    }
