    public class BlogRepository : IBlogRepository
    {
        // NHibernate object replace with our context
        private readonly BlogContext _blogContext;
        public BlogRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        //Function to get a list of blogs
        public IEnumerable<Post> Posts(int pageNo, int pageSize)
        {
            //We start with the blogs db set:
            var query = _blogContext.Posts
                //Filter by Published=true
                .Where(p => p.Published)
                //Order by date they were posted
                .OrderByDescending(p => p.PostedOn)
                //Jump through the list
                .Skip(pageNo * pageSize)
                //Get the required number of blogs
                .Take(pageSize)
                //Make sure the query include all the categories
                .Include(b => b.Category);
            //Just return what we have!
            return query;
        }
        //Much simpler function, should be pretty self explanatory
        public int TotalPosts()
        {
            return _blogContext.Posts.Where(p => p.Published).Count();
        }
    }
