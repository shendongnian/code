    String ConnStr = "Data Source=SqlServer; Initial Catalog=Database; User ID=Username; Password=Password";
    string SQL = "SELECT stationname FROM dbo.Stations WHERE StationID = @stationID";
    SqlCommand command = new SqlCommand(SQL, ConnStr);
    command.Parameters.Add(new SqlParameter("@stationID", SqlDbType.Int));
    command.Parameters["@stationID"].Value = textbox.Text;
