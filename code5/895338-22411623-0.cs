    public class DiscussionTopicPosts_Index : AbstractIndexCreationTask<DiscussionTopicPosts, DiscussionTopicPosts_Index.Post>
    {
        public class Post
        {
            public string DiscussionTopicPostsId { get; set; }
    
            public int Id { get; set; }
    
            public string Message { get; set; }
    
            public Guid PostedByLearnerId { get; set; }
    
            public DateTime InsertedUTC { get; set; }
        }
    
        public DiscussionTopicPosts_Index()
        {
            Map = topicPosts => from p in topicPosts
                                from post in p.Posts
                                where post.IsEnabled == true
                                select new
                                {
                                    DiscussionTopicPostsId = p.Id,
                                    Id = post.Id,
                                    Message = post.Message,
                                    PostedByLearnerId = post.PostedByLearnerId,
                                    InsertedUTC = post.InsertedUTC,
                                };
    
            Store(x => x.DiscussionTopicPostsId, FieldStorage.Yes);
            Store(x => x.Id, FieldStorage.Yes);
            Store(x => x.Message, FieldStorage.Yes);
            Store(x => x.PostedByLearnerId, FieldStorage.Yes);
            Store(x => x.InsertedUTC, FieldStorage.Yes);
    
            Sort(x => x.Id, SortOptions.Int);
        }
    }
