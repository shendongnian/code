    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        //method implementations removed for clarity
    
    }
    
    public class PartTime:Employee
    {
        public PartTime(string firstName, string lastName)
            : base(firstName, lastName)
        {
    
        }
    }
