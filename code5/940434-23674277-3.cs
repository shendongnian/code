    string commandText = "SELECT employeeID, name, position, hourlyPayRate " +
                         "FROM dbo.employee WHERE name LIKE '%'+ @Name + '%'";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        //Create a SqlCommand instance
        SqlCommand command = new SqlCommand(commandText, connection);
        //Add the parameter
        command.Parameters.Add("@Name", SqlDbType.VarChar, 20).Value = textbox1.Text;
        //Execute the query
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch
        {
            //Handle exception, show message to user...
        }
        finally
        {
            connection.Close(); 
        }
    }
