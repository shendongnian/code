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
