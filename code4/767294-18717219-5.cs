	Item[] items = { new Item {Id = 1, Items = new List<Item> 
	{ 
		new Item {Id = 2,  Items = new List<Item> {new Item { Id = 4, Items = new List<Item>()}}},
		new Item {Id = 3,  Items = new List<Item>()},
	}}};
	
	var path = Path(items, e => e.Items, e => e.Id == 4);
	// prints '1 -> 2 -> 4'
	Console.WriteLine(String.Join(" -> ", path.Select(i=>i.Id)));
