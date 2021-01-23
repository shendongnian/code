    class DownloadedImage
    {
        public Uri Uri { get; set}
        public string Name { get; set; }
        public Image Image { get; set; }
    
        public bool IsDownloaded { get { return image != null; } }
    }
