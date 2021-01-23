    private bool YourValidationFunction(string UserName, string Password)
    {
        bool boolReturnValue = false;
        string strConnection = "i wrote correct string, cannot write here on stackoverflow";
        String SQLQuery = "SELECT count(*) FROM aspnet_Users where Username=@uname AND Password = @pwd";
        using(SqlConnection sqlConnection = new SqlConnection(strConnection))
        using(SqlCommand command = new SqlCommand(SQLQuery, sqlConnection))
        {
            sqlConnection.Open();
            command.Parameters.AddWithValue("@uname", Username);
            command.Parameters.AddWithValue("@pwd", Password);
            int result = Convert.ToInt32(command.ExecuteScalar());
            boolReturnValue = (result > 0);
        }
        return boolReturnValue;
    }
