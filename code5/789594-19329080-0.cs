    public class EmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository=employeeRepository;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            IEnumerable<Employee> employeeList=this.employeeRepository.GetAll();
            //Optionally do some processing here
            return employeeList;
        }
    }
