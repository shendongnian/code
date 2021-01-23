    var queryParameters = new DynamicParameters();
    queryParameters.Add("@Param0", datatable0.AsTableValuedParameter());
    queryParameters.Add("@Param1", datatable1.AsTableValuedParameter());
    var result = await ExecuteStoredProc("usp_InsertUpdateTest", queryParameters);
    private async Task<Result<int>> ExecuteStoredProc(string sqlStatement, DynamicParameters parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    var affectedRows = await conn.ExecuteAsync(
                        sql: sqlStatement,
                        param: parameters,
                        commandType: CommandType.StoredProcedure);
                    return Result.Ok(affectedRows);
                }
            }
            catch (Exception e)
            {
                //do logging
                return Result.Fail<int>(e.Message);
            }
        }
