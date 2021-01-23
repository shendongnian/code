	public string CategoryTree(int? parentId)
	{
		using (DataContext db = new DataContext())
		{
			var tree = CategoryTree(db, parentId);
			Action<string> prune = tag =>
			{
				foreach (var empty in tree
					.Descendants(tag)
					.Where(ul => !ul.Descendants("a").Any())
					.ToArray())
				{
					empty.Remove();
				}
			};
			prune("ul");
			prune("li");
			return tree.ToString();
		}
	}
