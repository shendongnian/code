    try
    {
        SqlCommand command = new SqlCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = sc;
        command.CommandText = "InsertDars";
        //watch for appropriate SqlDbType
        //reference: http://msdn.microsoft.com/de-de/library/system.data.sqldbtype(v=vs.110).aspx
        command.Parameters.Add("@id", SqlDbType.Int).Value = tbldrs.ID;
        command.Parameters.Add("@id", SqlDbType.VarChar).Value = tbldrs.Name;
        command.Parameters.Add("@id", SqlDbType.VarChar).Value = tbldrs.Vahed;
        command.ExecuteNonQuery();
    }
