    public IEnumerable<Blog> Posts(int pageNo, int pageSize)
    {
        using(BlogEntities con = new BlogEntities())
        {
            var query = con.Post.Include("Category") //<-- If you set "Pluralize fields and properties" when creating your model, it will be "Posts" and "Categories"
                        .Where(p => p.Published)
                        .OrderByDescending(p => p.PostedOn)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .ToList();
             
            return query;
        }
    }
    public int TotalPosts()
    {
        using(BlogEntities con = new BlogEntities())
        {
              return con.Post.Where(p => p.Published).Count();
        }
       
    }
