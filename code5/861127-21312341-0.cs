    private void CheckLoginExist()
    {
        DataTable dt = new DataTable();
        String userName = UserBox.Text;
       string connectionString = @"Data Source=.\SQLEXPRESS;Database=Employee;Integrated Security=true";
       using (SqlConnection connection = new SqlConnection(connectionString))
       {
             SqlDataAdapter da = new SqlDataAdapter("SELECT UName FROM EVUSERS WHERE UName = '" + userName  + "'", _conn);                 
             da.Fill(dt); 
       }
    }
