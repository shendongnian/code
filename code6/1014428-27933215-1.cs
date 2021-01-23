        private void DetachDatabase()
        {
            String databaseConnectionString = "Data Source=localhost;MultipleActiveResultSets=True;Integrated Security=True";
            using (SqlConnection sqlDatabaseConnection = new SqlConnection(databaseConnectionString))
            {
                try
                {
                    sqlDatabaseConnection.Open();
                    string commandString = "ALTER DATABASE YOUR_DATABASE SET OFFLINE WITH ROLLBACK IMMEDIATE ALTER DATABASE YOUR_DATABASE SET SINGLE_USER EXEC sp_detach_db 'YOUR_DATABASE'";
                    SqlCommand sqlDatabaseCommand = new SqlCommand(commandString, sqlDatabaseConnection);
                    sqlDatabaseCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
