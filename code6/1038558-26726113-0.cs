    public class PostsViewModel
    {
        public Posts PostData { get; private set; }
        public PostsViewModel()
        {
            PostData = new Posts();
            GetPosts();
        }
        private async void GetPosts() 
        {
            // ...
        }
    }
