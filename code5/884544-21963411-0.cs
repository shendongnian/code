	var list = new List<YourType>
	{
		prod1, prod2, prod3, prod4, prod5
	};
	list
		.Select((prod, i) => String.Format("{0}. {1}\n\n", i, prod.GetDetails()))
		.ToList()
		.ForEach(Console.WriteLine);
