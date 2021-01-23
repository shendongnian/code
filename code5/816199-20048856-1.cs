    class EmployeeStrategyProvider
    {
        private readonly IEmployeeHandler[] _employeeHandlers;
        public EmployeeStrategyProvider(IEmployeeHandler[] employeeHandlers)
        {
            _employeeHandlers = employeeHandlers;
        }
        public IEmployeeHandler GetStrategy(string employeeType)
        {
            return _employeeHandlers.FirstOrDefault(item => item.EmployeeType == employeeType);
        }
    }
