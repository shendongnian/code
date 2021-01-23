    public class EmployeeApiController : ApiController
    {
        private readonly IEmployee _employeeRepositary;
    
        public EmployeeApiController()
        {
            _employeeRepositary = new EmployeeRepositary();
        }
    
        public async Task<HttpResponseMessage> Create(EmployeeModel Employee)
        {
            var returnStatus = await _employeeRepositary.Create(Employee);
            return Request.CreateResponse(HttpStatusCode.OK, returnStatus);
        }
    } 
