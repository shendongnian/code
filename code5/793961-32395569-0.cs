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
 
    Persistance
        public async Task<ResponseStatusViewModel> Create(EmployeeModel Employee)
            {    
            var responseStatusViewModel = new ResponseStatusViewModel();
            var connection = new SqlConnection(EmployeeConfig.EmployeeConnectionString);
                        var command = new SqlCommand("usp_CreateEmployee", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        var pEmployeeName = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);
                        pEmployeeName.Value = Employee.EmployeeName;
                        command.Parameters.Add(pEmployeeName);
            
                        
                        try
                        {
                            await connection.OpenAsync();
                            await command.ExecuteNonQueryAsync();
            
                            command.Dispose();
                            connection.Dispose();
            
                        }
                        catch (Exception ex)
                        {
            
                            throw ex;
                        }
                        return responseStatusViewModel;
                    }
    
        
    Repository
    
    Task<ResponseStatusViewModel> Create(EmployeeModel Employee);
    public class EmployeeConfig
        {
            public static string EmployeeConnectionString;
            private const string EmployeeConnectionStringKey = "EmployeeConnectionString";
            public static void InitializeConfig()
            {
                EmployeeConnectionString = GetConnectionStringValue(EmployeeConnectionStringKey);
            }
    
            private static string GetConnectionStringValue(string connectionStringName)
            {
                return Convert.ToString(ConfigurationManager.ConnectionStrings[connectionStringName]);
            }
        }
