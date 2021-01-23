    public abstract class GalleryItem
    {
        public string id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public bool is_album { get; set; }
    }
    public class GalleryImage : GalleryItem
    {
        // ...
    }
    public class GalleryAlbum : GalleryItem
    {
        public int images_count { get; set; }
        public List<GalleryImage> images { get; set; }
    }
