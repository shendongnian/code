    String ConnStr = "Data Source=SqlServer; Initial Catalog=Database; User ID=Username; Password=Password";
    string sql = "SELECT stationname FROM dbo.Stations WHERE StationID = @stationID";
    SqlCommand command = new SqlCommand(sql, cn);
    command.Parameters.Add(new SqlParameter("@stationID", SqlDbType.Int));
    command.Parameters["@stationID"].Value = textbox.Text;
