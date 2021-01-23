    class Posts
    {
        public string PostId { get; set; }
        public string PostStory { get; set; }
        public string PostMessage { get; set; }
        public string PostPicture { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
     try
            {
                var client = new FacebookClient(token);
                dynamic result = client.Get("/me/posts");
                List<Posts> postsList = new List<Posts>();
