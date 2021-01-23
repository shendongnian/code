    public static List<DBTrack> GetListOfTracks()
    {
        try
        {
            if (DBTrackData == null)
            {
                string myConnectionString = "Data Source="; // I have taken off the source
                string mySelectString = "SELECT TrackID, AddedDate, TrackName, ArtistName from TBL_Track";
                using (OleDbConnection myConnection = new OleDbConnection(myConnectionString))
                {
                   myConnection.Open();
                   using (OleDbCommand myCommand = new OleDbCommand(mySelectString, myConnection))
                   {
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
                       }
                       DBTrackData = list;
                   }
                }
            }
            return DBTrackData;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        return DBTrackData;
    }
