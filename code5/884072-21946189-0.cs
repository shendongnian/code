    var query = "select * from someTable where ProgramServer = @machineName and Active = 1;";
    using(var conn = new SqlConnection(connString))
    {
        var command = new SqlCommand(query, conn);
        command.Parameters.Add("machineName", machineName.ToString());
        // Execute and get the results
    }
