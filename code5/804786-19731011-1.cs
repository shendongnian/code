    string CommandText = "SELECT holiday_name "
                   + "FROM holiday "
                   + "WHERE holiday_name LIKE @name;"
    Connection = new SqlConnection(ConnectionString);
    try
    {
      string searchTerm = string.Format("%{0}%", HolidatyTextBox.Text);
      Connection.Open();
      Command = new SqlCommand(CommandText, Connection);
      Command.Parameters.Add(new SqlParameter("@name", searchTerm));
      var results = Command.ExecuteScalar();
    }
