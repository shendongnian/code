    private bool AuthenticateMe(string userName, string password)
    {
        string connectionString = @".....";
        string commandText = "SELECT COUNT(*) from [Table] where Username = @name AND Pass = @pwd");
        using(SqlConnection sqlConnection1 = new SqlConnection(connectionString))
        using(SqlCommand cmd = new SqlCommand(commandText, sqlConnection1))
        {
             sqlConnection1.Open();
             cmd.Parameters.AddWithValue("@name", username);
             cmd.Parameters.AddWithValue("@pwd", password);
             int result = (int)cmd.ExecuteNonQuery();
             return (result > 0);
        }
    }
