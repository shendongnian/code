    public class CustomViewModel
    {
        public CustomViewModel()
        {
            this.ShortPosts = new List<ShortPostViewModel>();
            this.Tags = new List<TagsViewModel>();
        }
        public List<ShortPostViewModel> ShortPosts { get; set; }
        public List<TagsViewModel> Tags { get; set; }
    }
