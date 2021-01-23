    public enum EmployeeType
    {
        Manager,
        Secretary
    }
    public class Employee
    {
        public Employee(EmployeeType type)
        {
            this.Type = type;
        }
        public string Code { get; set; }
        public EmployeeType Type { get; private set; }
    }
    public class Manager : Employee
    {
        public Manager()
            : base(EmployeeType.Manager)
        {
        }
        public void Manage()
        {
            // Managing
        }
    }
    public class Secretary : Employee
    {
        public Secretary()
            : base(EmployeeType.Secretary)
        {
        }
        public void SetMeeting()
        {
            // Setting meeting
        }
    }
