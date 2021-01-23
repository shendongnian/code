	string[,] original = new string[4, 3] 
	{ 
		{"apple","price1", "2"}, 
		{"orange","price2", "10"} , 
		{"Pineapple","price5", "1"}, 
		{"Kiwi","price3", "5"}
	};
	// 
	var indexAndOrder = new List<Tuple<int, int>>();
	for (var i = 0; i < original[0,0].Length - 1; i++)
	{
		var current = int.Parse(original[i, 2]);
		indexAndOrder.Add(new Tuple<int, int>(i, current));
	}
	// anonymous object to sort the indeces
	var sortedIndicesAsc = indexAndOrder.Select (ao => new { Index = ao.Item1, Value = ao.Item2}).ToList().OrderBy (ao => ao.Value).Select (ao => ao.Index);
	//var sortedIndicesDesc = indexAndOrder.Select (ao => new { Index = ao.Item1, Value = ao.Item2}).ToList().OrderByDescending (ao => ao.Value).Select (ao => ao.Index);
	// iterate over indices => sorted array
	foreach (var index in sortedIndicesAsc)
	{
		Console.WriteLine(string.Format("{0} - {1} - {2}", original[index, 2], original[index, 0], original[index, 1]));
	}
