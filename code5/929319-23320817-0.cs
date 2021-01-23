    public class Picture : PictureBox
    {
        public Bitmap Thumbnail { get; set; }
        public Bitmap OriginalPhoto { get; set; }
        public string Name { get; set; }
        public Int64 Order { get; set; }
    }
