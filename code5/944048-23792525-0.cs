    public class Album
       {
           public int IDNumber { get; set; }
           public string AlbumName { get; set; }
           public string Artist { get; set; }
           public int ReleaseDate { get; set; }
           public int TrackAmount { get; set; }
           public string Location { get; set; }
           public int Rating { get; set; }
    
           public Album(int _id, string _name, string _artist, int _releasedate, int _trackamount, string _location, int _rating)
           {
               IDNumber = _id;
               AlbumName = _name;
               Artist = _artist;
               ReleaseDate = _releasedate;
               TrackAmount = _trackamount;
               Location = _location;
               Rating = _rating;
           }
       }
