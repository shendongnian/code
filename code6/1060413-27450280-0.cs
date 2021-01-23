    private void ExecuteTwoCommands ()
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
    }
    // here You need to use Your stored procedure
    command.CommandText = "MyStoredProc";
    command.CommandType = CommandType.StoredProcedure;
    // do smoething with new command for exaple:
    command.ExecuteNonQuery;
    }
