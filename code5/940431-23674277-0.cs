    string commandText = "SELECT employeeID, name, position, hourlyPayRate " +
                         "FROM dbo.employee WHERE name LIKE '%'+ @Name + '%'";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        command.Parameters.Add("@Name", SqlDbType.VarChar, 20).Value = textbox1.Text;
        //execute the query...
    }
