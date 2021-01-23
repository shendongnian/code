    TNDbContext context = DataContext;
    //Create the base query:
    var query = context.Posts
            .Include(a => a.Tags)
            .Include(b => b.Comments)
            .OrderByDescending(x => x.Views);
    //Refine this query by adding "where" filters for each search term:
    if(!string.IsNullOrWhitespace(searchTerm))
    {
        string[] terms = searchTerm.Split(" ,".ToCharArray(),
                                          StringSplitOptions.RemoveEmptyEntries);
        foreach(var x in terms)
        {
            string term = x;
            query = query.Where(post => (post.Title.Contains(term) ||
                                         post.Tags.Any(tag => tag.Name.StartsWith(term))));
        }
    }
    //Run the final query to get some results:
    var result = query.ToPagedList(page, resultsPerPage);
    return result;
