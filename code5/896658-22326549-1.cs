    public class ManagerType : IEmployeeType
    {
        public Employee Create()
        {
            return new Manager();
        }
    }
