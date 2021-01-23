    var groups = (from p in posts
				  group p by p.Group into g
				  select new 
					{
					   Id = g.Max(p => p.Id),
					   Group = g.Key
					}).ToList();
    var bestPosts = (from p in posts
					join j in groups on new {p.Group, p.Votes} equals new {j.Group, j.Votes}
					select p).ToList();
