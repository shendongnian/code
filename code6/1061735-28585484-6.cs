    public class VideoItem
    {
        public string Url { get; private set; }
        public ImageSource Thumbnail { get; set; }
        public VideoItem(string url)
        {
            this.Url = url;
        }
    }
