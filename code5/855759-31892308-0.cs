    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using Dapper;
    using Newtonsoft.Json;
    using Repository.DTO;
    
    namespace Repository.Repositories
    {
        public class EmployeeRepo
        {
            public IEnumerable<EmployeeModel> AllEmployees()
            {
                try
                {
                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Read"].ConnectionString))
                    {
                        const string query = @"select EmpID, FirstName [First] from employee";
                        return connection.Query<EmployeeModel>(query);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(e));
                    throw;
                }
            }
        }
    }
