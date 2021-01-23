    string constring = @""; // Declare your connection string here.
    String SQL = "SELECT stationname FROM dbo.Stations WHERE StationID = @StationId;
    SqlConnection con = new SqlConnection(constring);
    con.Open();
    SqlCommand command = new SqlCommand(SQL ,con);
