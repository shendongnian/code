    [RoutePrefix("api/employee")
    public class EmployeeController : ApiController
    {
        private readonly IRepository<Employee> _employees; 
        public EmployeeController(IRepository<Employee> repo)
        {
            _employees = repo;
        }
        [Route("")]
        public IEnumerable<Employee> GetEmployees()
        {
            return _employees.Queryable();
        }
        [Route("{id}")]
        public Employee GetEmployee(int id)
        {
            return _employees.Queryable().FirstOrDefault();
        }
    }
    
