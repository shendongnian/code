    public interface IEmployeeType
    {        
    }
    public class Employee
    {
        public Employee(IEmployeeType employeeType)
        {
            EmployeeType = employeeType;
        }        
        public IEmployeeType EmployeeType { get; private set; }
    }
    public class Secretary : Employee
    {
        public Secretary(IEmployeeType type) : base(type)
        {            
        }        
    }
    // Example:
    // Will compile on JAVA platform
    // Will Not compile on .Net platform
    //public enum EmployeeType : IEmployeeType
    //{
    //    Manager,
    //    Secretary        
    //}
