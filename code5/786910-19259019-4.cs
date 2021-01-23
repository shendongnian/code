	List<string> nameColumn;
	using (var context = new Context)
	{
		var repository = new Repository<Product>(context);
		nameColumn = repository.GetColumn(x => x.Name);
	}
