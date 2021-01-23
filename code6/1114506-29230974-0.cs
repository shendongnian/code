    public void Save(SqlConnection apmConn)
    {
        SqlCommand scCommand = new SqlCommand("spLocationsCreate", apmConn);
            scCommand.CommandType = CommandType.StoredProcedure;
            scCommand.Parameters.Add("@LocationCode", SqlDbType.VarChar, 5).Value = this.LocationCode;
            scCommand.Parameters.Add("@Location", SqlDbType.NVarChar, 100).Value = this.Locations;
            scCommand.Connection.Open();
            scCommand.ExecuteNonQuery();
            scCommand.Connection.Close();
    }
