	var itemDictionary = new Dictionary<int, CustomControl>();
	
	foreach (var item in items)
	{
		itemDictionary[item.indent] = new CustomControl()
		{
			Id = item.id,
			Name = item.name,
			Children = new List<CustomControl>(),
		};
		if (item.indent != 0)
		{
			itemDictionary[item.indent].ParentId =
				itemDictionary[item.indent - 1].Id;
			itemDictionary[item.indent - 1]
				.Children.Add(itemDictionary[item.indent]);
		}
	}
