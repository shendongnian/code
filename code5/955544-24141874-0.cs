    DBTrack top = new DBTrack
    {
       TrackID = SQLDataHelper.GetGuid(dataReader, "TrackID"),
       TrackName = SQLDataHelper.GetString(dataReader, "TrackName"),
       ArtistName = SQLDataHelper.GetString(dataReader, "ArtistName"),
       AddedDate = SQLDataHelper.GetDateTime(dataReader, "AddedDate")
    };
