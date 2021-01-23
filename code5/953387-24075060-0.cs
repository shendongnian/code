    public static int CheckForExistingTimecard(int userId, int payPeriodId)
    {
       using (SqlConnection connection = new SqlConnection(dbMaintenanceConnectionString))
       using (SqlCommand sqlCommand = new SqlCommand("spCheckForExistingTimecard", connection))
       {
           sqlCommand.CommandType = CommandType.StoredProcedure;
           sqlCommand.Parameters.AddWithValue("@userId", userId);
           sqlCommand.Parameters.AddWithValue("@payPeriodId", payPeriodId);
           -- define your parameter for the RETURN value
           sqlCommand.Parameters.Add("@ReturnValue").Direction = ParameterDirection.ReturnValue;
           connection.Open();
           sqlCommand.ExecuteNonQuery();
           -- read the value returned
           int returnValue = (int)sqlCommand.Parameters["@ReturnValue"];
           connection.Close();
           return returnValue;
       }
    }
