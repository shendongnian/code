    TopPlayed top = new TopPlayed()    
    {
        TrackID = p.Field<Int64>("ID"),
        TrackName = p.Field<string>("Track Name"),
        ArtistName = p.Field<string>("Artist Name"),
        Times = p.Field<double>("NoOfPlays").ToString()
    };
    public class TopPlayed
    {
        public Int64 TrackID { get; set; }
        public string TrackName { get; set; }
        public string ArtistName { get; set; }
        public string Times { get; set; }
    }
