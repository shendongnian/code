    using (connection)
    {
          DataTable wiInfo = GetWeatherInfo();
          SqlCommand insertCommand = new SqlCommand("usp_InsertWeatherInfo", connection);
          insertCommand.CommandType = CommandType.StoredProcedure;
          SqlParameter tvpParam = insertCommand.Parameters.AddWithValue("@tbpWeatherInfo", wiInfo);
          tvpParam.SqlDbType = SqlDbType.Structured;
          insertCommand.ExecuteNonQuery();
    }
    private DataTable GetWeatherInfo()
    {
        DataTable wi = new DataTable();
        wi.Columns.Add("infoDate", typeof(DateTime));
        wi.Columns.Add("minTemp", typeof(double));
        wi.Columns.Add("maxTemp", typeof(double));
        ... loop reading aline of weather info ....
            DataRow row = wi.NewRow();
            wi["infoDate"] = ... datetime from line ....
            wi["minTemp"] = ... minTemp from line ....
            wi["maxTemp"] = ... maxTemp from line ....
            wi.Rows.Add(row);
        ... next line
        return wi;
    }
  
