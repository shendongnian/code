    public enum EmployeeType
    {
        UnKnown,//this can be used for extensiblity
        Manager,
        Secretary,    
    }
    
    public abstract class Employee//<--1
    {
        public string Code { get; set; }
    
        public abstract EmployeeType Type { get; } //<--2
    }
    
    public class Manager : Employee
    {
        public override EmployeeType Type { get { EmployeeType.Manager; } }//<--3
        public void Manage()
        {
            // Managing
        }
    }
    
    public class Secretary : Employee
    {
        public override EmployeeType Type { get { EmployeeType.Secretary; } }//<--4
        public void SetMeeting()
        {
            // Setting meeting
        }
    }
