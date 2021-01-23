	BlogsManager blogsManager = BlogsManager.GetManager();
	var bb = blogsManager.GetBlogPosts()
						 .Where(b => b.Status == ContentLifecycleStatus.Live)
						 .ToList();
	foreach (var blogItem in bb)
	{
		var blogID = blogItem.Id;
		var categoryIds = blogItem.GetValue<TrackedList<Guid>>("Category");
		var taxonomyManager = TaxonomyManager.GetManager();
		foreach (var catId in categoryIds)
		{
			var taxon = taxonomyManager.GetTaxon(catId);
			var id = taxon.Id;
			var name = taxon.Name;
			
		}
	}
