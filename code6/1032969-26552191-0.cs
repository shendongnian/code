    // var blogs = blogRepo.GetBlogs();
    var start = DateTime.Now.AddDays(-1);
    var best =
    	from blog in blogs
    	let total = blog.Stats.Where(s => s.Date > start).Sum(i => i.Views)
    	orderby total descending
    	select new
    	{
    		blog, total
    	};
    
    var results = best.Take(3);
