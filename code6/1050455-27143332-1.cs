    Song(ID,Title,ReleaseDate)
    Album(ID,Title,ReleaseDate)
    Artist(ID,FirstName,LastName)
    RelatedSong(ID,ParentID,SongID,ArtistID,AlbumID,TrackNumber)
    [Table("RelatedSong")]
    public partial class RelatedSong
    {
        public Guid ID { get; set; }    
        public Guid ParentID { get; set; }    // this will be used for the Parent Song
        public Guid SongID { get; set; }    
        public Guid ArtistId {get; set;} // this will be used for artist foreign key
        public Guid AlbumId {get; set;} // this will be used for album foreign key
        public int? TrackNumber { get; set; }    
        public virtual Album Album { get; set; }    
        public virtual Artist Artist { get; set; }    
        public virtual Song Song { get; set; }
    }  
     modelBuilder.Entity<Album>()
                .HasMany(e => e.RelatedSongs)
                .WithRequired(e => e.Album)
                .HasForeignKey(e => e.ParentID) // here you should use AlbumId and not ParentID
                .WillCascadeOnDelete(false);
    modelBuilder.Entity<Artist>()
                .HasMany(e => e.RelatedSongs)
                .WithRequired(e => e.Artist)
                .HasForeignKey(e => e.ParentID) // here you should use ArtistId and not ParentID, which you already used it in the Album above
     modelBuilder.Entity<Song>()
                .HasMany(e => e.RelatedSongs)
                .WithRequired(e => e.Song)
                .HasForeignKey(e=>e.ParentID); // here you will use the parent id for the song relation
                .WillCascadeOnDelete(false);
