    // Data layer method
    public static DataSet GetProductsByOccasion(int empPercent)
    {
        SqlParameter[] parameters = new SqlParameter[1];
        
        parameters[0] = new SqlParameter("@Emp_Persent", 
            System.Data.SqlDbType.Int, 8, "empPercent");
        parameters[0].Value = empPercent;
        
        using (SqlConnection dbConnection = new SqlConnection(connectionString))
        {
            try
            {
                return (SqlHelper.ExecuteDataset(dbConnection, 
                    CommandType.StoredProcedure,
                        "GetEmployeesByPercent", parameters));
            }
            catch
            {
                throw;
            }
        }
    }
