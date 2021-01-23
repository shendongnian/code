    public class Track
            {
                internal enum Category
                {
                    Ambient, Blues, Country, Disco, Electro,  Hardcore,
                    HardRock, HeavyMetal, Hiphop, Jazz, Jumpstyle, Klassiek, Latin, 
                    Other, Pop, Punk, Reggae, Rock, Soul, Trance, Techno
                }
    
                public Track(int id, string name, string artist, 
                             string albumSource, Category category, 
                              TimeSpan duration)
                {
                    Id = id;
                    Name = name;
                    Artist = artist;
                    AlbumSource = albumSource;
                    TrackCategory = category;
                    Duration = duration;
                }
    
                public TimeSpan Duration { get; set; }
    
                public Category TrackCategory { get; set; }
    
                public string AlbumSource { get; set; }
    
                public string Artist { get; set; }
    
                public string Name { get; set; }
    
                public int Id { get; set; }
    
                public override string ToString()
                {
                    return string.Format("{0} by {1} is {2} long", 
                                            Name, Artist, Duration);
                }
            }
