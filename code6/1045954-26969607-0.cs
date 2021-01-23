    class Employee
    {
        static int _empCount = 0;
        static int GetNextEmployeeId()
        {
            _empCount++;
            return _empCount;
        }
        public int EmployeeId { get; private set; }
        public Employee()
        {
            EmployeeId = GetNextEmployeeId();
        }
    }
