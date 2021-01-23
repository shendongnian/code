    private static List<DBTrack> DBTrackData
    public static List<DBTrack> GetListOfTracks()
    {
        if (DBTrackData == null)
        {
           ...
        
           DBTrackData = new List<DBTrack>();
           while (myReader.Read())
           {
               DBTrack data = new DBTrack();
               ...
               DBTrackData.Add(data);
           };
        }
    
       return DBTrackData;
    }
