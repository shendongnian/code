	// remove Value
	var rootNodes = new List<Node>();
	foreach (var pair in map)
	{
		if (pair.ParentId.HasValue) 
		{
			var parent = map[pair.ParentId.Value]; 
			pair.Parent = parent; 
			parent.Children.Add(pair);
			parent.Operator = pair.Operator;
		}
		else
		{
			rootNodes.Add(pair);	
		}
	}
