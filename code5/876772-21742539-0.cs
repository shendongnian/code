    private bool MethodName(string inviteId)
    {
      var command = new SqlCommand
      {
        CommandText = "SELECT statement goes here",
        Connection = conn
      } ;
      var reader = command.ExecuteReader();
      return reader.Read();
    }
