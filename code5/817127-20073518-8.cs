    public class Track
    {
      public int ID {get;set;}
      public string Name {get;set;}
      public virtual ICollection<Playlist> Playlists {get;set;}
    }
