      public class Blog
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
        }
    
    
        public class BlogViewModel
        {
    
            public Guid PostId { get; set; }
    
            public string Title { get; set; }
        }
    
      public static class BlogMapper
        {
       public static IEnumerable<BlogViewModel> ConvertToPostListViewModel(this IEnumerable<Blog> posts)
            {
                Mapper.CreateMap<Blog, BlogViewModel>()
                    .ForMember(blo => blo.PostId, bl => bl.MapFrom(b => b.Id));
                return Mapper.Map<IEnumerable<Blog>, IEnumerable<BlogViewModel>>(posts);
            }
        }
