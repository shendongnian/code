       using (var sqlConnection = new SqlConnection("connection"))
       {
           var commandText = "SELECT employeeID, name, position, hourlyPayRate FROM dbo.employee WHERE name LIKE @name";
    
           using (var sqlCommand = new SqlCommand(commandText, sqlConnection))
           {
                 sqlCommand.Parameters.Add("@salary", SqlDbType.Money).Value = textBox1.text;
           }
       }
