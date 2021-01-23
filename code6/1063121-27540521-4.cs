    private bool YourValidationFunction(string UserName, string Password)
    {
        
        string strConnection = "server=example;database=TEST_dw;uid=test;pwd=test;";
        SqlConnection sqlConnection = new SqlConnection(strConnection);
        sqlConnection.Open();
        String query = "SELECT Count(*) FROM Login WHERE UserName=@UserName AND Password=@Password";
        SqlCommand command = new SqlCommand(query, sqlConnection);
        command.Parameters.AddWithValue("@UserName", UserName);
        command.Parameters.AddWithValue("@Password", Password);
        int result = Convert.ToInt32(command.ExecuteScalar());
        sqlConnection.Close();
        return result != 0 ? true : false;
    }
