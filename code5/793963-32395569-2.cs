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
    
        
