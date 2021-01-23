	var items = new[]{
						new Item{Id =1, Name = "Bangles", Price=100},
						new Item{Id =2, Name = "Saree",   Price=200},
						new Item{Id =3, Name = "Shoes",   Price=150},
						new Item{Id =4, Name = "Bangles", Price=100},
						new Item{Id =5, Name = "Shoes",   Price=150}
					 };
						
	
	var distinctItems = items.GroupBy(i => new{i.Name, i.Price})
                             .Select(g => g.First());
	
	foreach (var item in distinctItems)
	{
		Console.WriteLine ("Name: {0} Price: {1}", item.Name, item.Price);
	}	
