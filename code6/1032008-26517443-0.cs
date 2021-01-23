    class MyProgram
    {
        private static List<string> _failedEmployeeIds;
        private static List<Employee> _successfullyCreatedEmployees;
        static void Main(string[] args)
        {
            _failedEmployeeIds = new List<string>();
            _successfullyCreatedEmployees = new List<Employee>();
            TryCreateEmployee("111-11-111", -4.0);
            TryCreateEmployee("222-22-222", 7.5);
            TryCreateEmployee("333-33-333", 750);
            ProcessFailedEmployees(); // do something here
            ProcessCreatedEmployees(); // do something here
        }
        static void TryCreateEmployee(string employeeId, double employeeWage)
        {            
            try
            {
                var employee = new Employee(employeeId, employeeWage);
                _successfullyCreatedEmployees.Add(employee);
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);
                _failedEmployeeIds.Add(employeeId);
            }
        }
    }
    class Employee
    {
        private string _id;
        private double _hourlyWage;
        public double HourlyWage
        {
            get { return _hourlyWage; }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new EmployeeException("Value must be greater than 0 and less than 254");
                }
                _hourlyWage = value;
            }
        }
        public Employee(string Id, double hourlyWage)
        {
            _id = Id;
            HourlyWage = hourlyWage;
        }
    }
