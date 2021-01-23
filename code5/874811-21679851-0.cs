        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Trading.mdb";
        string commandText = "INSERT INTO Order (OpenDate) VALUES (?)";
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(commandText, connection);
            command.Parameters.AddWithValue("@OpenDate", DateTime.Now);
            try
            {
                command.Connection.Open();
                int response = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: {0}" + ex.Message);
            }
        }         
