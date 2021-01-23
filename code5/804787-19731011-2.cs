    string CommandText = "SELECT holiday_name "
                   + "FROM holiday "
                   + "WHERE holiday_name LIKE @name;"
    Connection = new SqlConnection(ConnectionString);
    try
    {
      var escapedForLike = HolidatyTextBox.Text; // see note below how to construct 
      string searchTerm = string.Format("%{0}%", escapedForLike);
      Connection.Open();
      Command = new SqlCommand(CommandText, Connection);
      Command.Parameters.Add(new SqlParameter("@name", searchTerm));
      var results = Command.ExecuteScalar();
    }
