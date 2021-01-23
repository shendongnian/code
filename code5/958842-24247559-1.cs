    public static List<DBTrack> GetListOfTracks()
    {
       if (DBTrackData != null) return DBTrackData;
    
       string myConnectionString = "Data Source="; // I have taken off the source
       string mySelectString = "SELECT TrackID, AddedDate, TrackName, ArtistName from TBL_Track";
    
       OleDbConnection myConnection = new OleDbConnection(myConnectionString);
       OleDbCommand myCommand = new OleDbCommand(mySelectString, myConnection);
       myCommand.Connection.Open();
       OleDbDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
    
       List<DBTrack> list = new List<DBTrack>();
       while (myReader.Read())
       {
    	   DBTrack data = new DBTrack();
    	   data.TrackID = (Guid)(myReader["TrackID"]);
    	   data.AddedDate = (DateTime)myReader["AddedDate"];
    	   data.TrackName = (string)myReader["TrackName"];
    	   data.ArtistName = (string)myReader["ArtistName"];
    	   list.Add(data);
       };
    
       //Setting DBTrackData means these values will get returned on every call to GetListOfTracks for this instance of the class
       DBTrackData = list;
       return list;
    }
