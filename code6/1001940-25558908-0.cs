    public class FindPostsRequest : Request
    {
      public PostType Type { get; set; }
    }
    
    public class FindPostsResponse : Response
    {
      public IList<PostDto> Posts { get; set; }
    
      public class PostDto
      {
        public Int32  Id    { get; set; }
        public String Title { get; set; }
        public String Text  { get; set; }
      }
      public class PostDtoWithTags : PostDto
      {
        public List<String> Tags { get; set; }
      }
    }
    public class FindPostsByTypeHandler : Handler<FindPostsByTypeRequest, FindPostsByTypeResponse>
    {
    
      private IContext _context;
    
      public FindPostsByTypeHandler(IContext context) {_context = context;}
    
      public FindPostsByTypeResponse<tPostDto> Handle<tPosts>(FindPostsByTypeRequest request) where tPostDto : PostDto
      {
        IList<FindPostsByTypeResponse.PostDto> posts = _context.Posts
        .Where(x => x.Type == request.Type)
        .Select
        (
          x =>
          typeof(tPostDto) == typeof(PostDtoWithTags)
          ?  new FindPostsByTypeResponse.PostDtoWithTags
             {
               Id    = x.Id,
               Title = x.Title,
               Text  = x.Text,
               Tags  = x.Tags
             }
          :  new FindPostsByTypeResponse.PostDto
             {
               Id    = x.Id,
               Title = x.Title,
               Text  = x.Text
             }
         ).ToList();
         return new FindPostsByTypeResponse { Posts = posts };
      }
    }
