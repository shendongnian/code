    public class Album
    {
        public string Name {get;set;}
        public string Artist {get; set;}
        public Album(string _name, string _artist)
        {
             Name = _name;
             Artist = _artist;
        }
    }
    
    
    Album example = new Album("a", "good idea");
    
    List<Album> listOfAlbums = new List<Album>();
    listOfAlbums.Add(example);
