    interface IEmployeeHandler
    {
        string EmployeeType { get; }
        void Handle(Employee employee);
    }
    class ManagerHandler : IEmployeeHandler
    {
        public ManagerHandler()
        {
            EmployeeType = "Manager";
        }
        public string EmployeeType { get; private set; }
        public void Handle(Employee employee) { }
    }
    class ServantHandler : IEmployeeHandler
    {
        public ServantHandler()
        {
            EmployeeType = "Servant";
        }
        public string EmployeeType { get; private set; }
        public void Handle(Employee employee) { }
    }
