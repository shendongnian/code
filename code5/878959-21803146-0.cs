    try
    {
        using(SqlConnection conn = ...)
        {
            conn.Open();
            using(SqlCommand command = conn.CreateCommand())
            {
                command.CommandText = "SELECT @@VERSION";
                var result = (string) command.ExecuteScalar();
                MessageBox.Show("\nTEST SUCCESSFUL\n" + result); 
            }
        }
    }
    catch(Exception ex)
    {
        MessageBox.Show("TEST FAILED Exception Thrown: " + exception.Message);
    }
