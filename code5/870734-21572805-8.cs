    public class ViewModel
    {
        public List<ImageComment> ImageComments { get; set; }
        public ViewModel()
        {
            ImageComments = new List<ImageComment>();
        }
    }
    public class ImageComment
    {
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
    }
