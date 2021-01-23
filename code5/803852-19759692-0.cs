	public string CategoryTree(int? parentId)
	{
		using (DataContext db = new DataContext())
		{
			return CategoryTree(db, parentId).ToString();
		}
	}
	
	private XElement CategoryTree(DataContext db, int? parentId)
	{
		return new XElement(
			"ul", 
			from n in db.Categories
			join m in db.Products on n.CatId equals m.CategoryId
			where n.ParentId == parentId
			select new XElement(
				"li",
				new XElement(
					"a",
					new XAttribute(
						"href",
						"/Product/" + m.ProdId),
					n.Title),
				CategoryTree(db, n.CatId)));
	}
