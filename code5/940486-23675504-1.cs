            string connectionString = null;
        
            private void btnSearch_Click(object sender, EventArgs e)
            {
                connectionString = "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True" providerName="System.Data.SqlClient";";
                string commandText = "SELECT employeeID, name, position, hourlyPayRate " +
                         "FROM dbo.employee WHERE name LIKE '%'+ @Name + '%'";
    
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //Create a SqlCommand instance
                    SqlCommand command = new SqlCommand(commandText, connection);
                    //Add the parameter
                    command.Parameters.Add("@Name", SqlDbType.VarChar, 20).Value = textBox1.Text;
    
                    //Execute the query
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        //Handle excepetion, show message to user...
                        MessageBox.Show("Error bitch!");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
