	string[,] original = new string[4, 3] 
	{ 
		{"apple","price1", "2"}, 
		{"orange","price2", "10"} , 
		{"Pineapple","price5", "1"}, 
		{"Kiwi","price3", "5"}
	};
	// extract the data
	var indexAndOrder = new List<Tuple<string, string, int>>();
	for (var i = 0; i < original[0,0].Length - 1; i++)
	{
		var current = int.Parse(original[i, 2]);
		indexAndOrder.Add(new Tuple<string, string, int>(original[i,0], original[i,1], current));
	}
	// anonymous object to sort the indices
	var sortedArray = indexAndOrder
							.Select (ao => new { Name = ao.Item1, Price = ao.Item2, Index = ao.Item3})
							.ToList()				
							.OrderBy (ao => ao.Index)
							//.OrderByDescending (ao => ao.Index)
							.ToArray();
	foreach (var item in sortedArray)
	{
		Console.WriteLine(string.Format("{0} - {1} - {2}", item.Index, item.Name, item.Price));
	}
