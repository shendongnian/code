    using(SqlConnection conn = new  SqlConnection(connString))
    using(SqlCommand command = new SqlCommand(ProcName, conn))
    using(SqlDataAdapter da = new SqlDataAdapter(command))
    {
      command.CommandType = CommandType.StoredProcedure;
      da.Fill(dt);
    }
