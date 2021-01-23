    public class Employee
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
    
    public class RootObject
    {
        public List<Employee> employees { get; set; }
    }
