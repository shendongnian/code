    SqlParameter p = new SqlParameter();
    p.ParameterName = "@ReturnedValue";
    p.SqlDbType = SqlDbType.Int;
    p.Value = 0;
    p.Direction = ParameterDirection.InputOutput;
    SqlCmd.Parameters.Add(p);
