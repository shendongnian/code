    public class EmployeeController : ApiController
    {
        private readonly IRepository<Employee> _employees; 
        public EmployeeController(IRepository<Employee> repo)
        {
            _employees = repo;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _employees.Queryable();
        }
        public Employee GetEmployee(int id)
        {
            return _employees.Queryable().FirstOrDefault();
        }
    }
