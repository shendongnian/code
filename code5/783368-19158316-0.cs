	interface IBlogRepository
	{
		List<BlogDetail> GetAllBlogs();
	}
	class BlogRepository : IBlogRepository
	{
		public List<BlogDetail> GetAllBlogs()
		{
			using (var db = new BloggingContext("CodeFirstSampleConnectionString"))
			{
				return db.Database.SqlQuery<BlogDetail>("uspGetAllBlogs").ToList();
			}
		}
	}
	class Default
	{
		private readonly IBlogRepository _blogRepository;
		
		public Default(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}
		
		public List<BlogDetail> GetData()
		{
			return _blogRepository.GetAllBlogs();
		}
	}
