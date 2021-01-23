    string CommandText = "SELECT holiday_name "
                    + "FROM holiday "
                    + "WHERE holiday_name LIKE @name";
    Connection = new SqlConnection(ConnectionString);
    
    try
    {
        Connection.Open();
        Command = new SqlCommand(CommandText, Connection);
        string name = "%" + HolidayTextBox.Text + "%";
        Command.Parameters.Add(new SqlParameter("@name", name));
