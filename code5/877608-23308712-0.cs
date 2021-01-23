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
                for (int i = 0; i < result.Count; i++)
                {
                    Posts posts = new Posts();
                    posts.PostId = result.data[i].id;
                    if (object.ReferenceEquals(result.data[i].story, null))
                        posts.PostStory = "this story is null";
                    else
                        posts.PostStory = result.data[i].story;
                    if (object.ReferenceEquals(result.data[i].message, null))
                        posts.PostMessage = "this message is null";
                    else
                        posts.PostMessage = result.data[i].message;
                    posts.PostPicture = result.data[i].picture;
                    posts.UserId = result.data[i].from.id;
                    posts.UserName = result.data[i].from.name;
                    postsList.Add(posts);
                }
            }
            catch (Exception)
            {
                throw;
            }
