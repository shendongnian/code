	public static IEnumerable<ListView> listviews = (new Func<ListView>[]
	{
		() => tagListView,
		() => commonListView,
		() => recentListView,
	}).Select(x => x()).Where(x => x != null);
