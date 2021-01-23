    public class Employee
        {
            public Guid Id { get; private set; } = Guid.NewGuid();
            public string EmployeeName { get; set; }
            public string Address { get; set; }
        }
