    DataTable dt = new DataTable();
    cmd.CommandType = CommandType.StoredProcedure;
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(dt);
    Users = dt.AsEnumerable()
        .Select(r => r.Field<string>("ColumnName"))
        .ToList();
