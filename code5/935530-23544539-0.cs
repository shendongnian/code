    public class Picture
     {
        public int PictureId { get; set; }
        public IEnumerable<HttpPostedFile> Image { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string Path { get; set; }
    }
