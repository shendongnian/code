    private void ExecuteTwoCommands ()
    {
        var command = new SqlCommand
        {
            CommandText = "SELECT id FROM blah_tbl...",
            Connection = conn
        };
            using (var reader = command.ExecuteReader())
        {
            if (reader.Read())
        {
            user.Id = (int) reader["id"];
        }
        SqlCommand newCommand = new SqlCommand();
        newCommand.CommandText = "MyStoredProc";
        newCommand.CommandType = CommandType.StoredProcedure;
        // do smoething with new command for exaple:
        newCommand.ExecuteNonQuery;
    }
