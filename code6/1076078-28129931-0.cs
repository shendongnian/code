    public class AlbumPictureDto
    {
        public int id { get; set; }
        public string url{ get; set; }
        public string thumbnailUrl{ get; set; } //create new properties
        public new static readonly Func<AlbumPicture, AlbumPictureDto> AsDto = p => new AlbumPictureDto()
        {
            id = p.id,
            url= p.url,
            thumbnailUrl= ThumbManager.GetThumb(p.id)
    };
    }
