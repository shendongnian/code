    SqlConnection connString = new SqlConnection(@"Data Source=***;Initial Catalog=***;Integrated Security=True");    
    connString.Open();
    SqlCommand command = new SqlCommand("exec pr_upiteminvent", connString);
    command.ExecuteNonQuery();
    connString.Close();
