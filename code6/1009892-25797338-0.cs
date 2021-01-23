    SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader reader;
    
    cmd.CommandText = "SELECT top 5 * FROM games ORDER BY likes desc";
    cmd.CommandType = CommandType.Text;
    cmd.Connection = sqlConnection1;
    
    sqlConnection1.Open();
    
    reader = cmd.ExecuteReader();
    
    sqlConnection1.Close();
