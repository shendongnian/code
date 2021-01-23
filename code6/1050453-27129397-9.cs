        [Table("RelatedSong")]
        public partial class RelatedSong
        {
            public Guid ID { get; set; }
            public Guid? ParentID { get; set; }
    
            ...
        }
        [Table("RelatedAlbum")]
        public partial class RelatedAlbum
        {
            public Guid ID { get; set; }
            public Guid? ParentID { get; set; }
            public Guid? AlbumID { get; set; }
            ...
        }
