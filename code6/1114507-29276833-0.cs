    public void SaveLocation(SqlConnection APMConn)
    {
        SqlCommand scCommand = new SqlCommand("spLocationsCreate", APMConn);
        scCommand.CommandType = CommandType.StoredProcedure;
        scCommand.Parameters.Add("@LocationCode", SqlDbType.VarChar, 5).Value = _LocationCode;
        scCommand.Parameters.Add("@Location", SqlDbType.NVarChar, 100).Value = _Locations;
        scCommand.Connection.Open();
        scCommand.ExecuteNonQuery();
        scCommand.Connection.Close();
    }
