    public class Track
    {
      public int ID {get;set;}
      public int PlayListID {get;set;}
      public string Name {get;set;}
      public virtual Playlist Playlist {get;set;}
    }
