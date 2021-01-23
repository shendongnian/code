    SqlCommand cmd = new SqlCommand("select * from sometable where somecolumn = @Param1");
    cmd.Connection = _MyConnection;
    var param = new SqlParameter();
    param.ParameterName = "@Param1";
    param.Value = DBNull.Value;
    cmd.Parameters.Add(param);
    cmd.Connection.Open();
    try
    {
        cmd.ExecuteNonQuery();
    }
    finally
    {
        cmd.Connection.Close();
    }
