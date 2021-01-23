	float?[] A = { 0f, 1f, 2f, 5f, null, null, null, 7f, null, 8f };
	var result = A.Aggregate(Tuple.Create(new List<float>(), 0), 
     (items, current) => 
     {
	 	if(current.HasValue)
		{
			if(items.Item2 == 0)
				items.Item1.Add(current.Value);
			else
			{
				var avg = current.Value / (items.Item2 + 1);
				for(int i = 0; i <= items.Item2; i++)
					items.Item1.Add(avg);
			}
			return Tuple.Create(items.Item1, 0);
		}
		else
			return Tuple.Create(items.Item1, items.Item2 + 1);
     }).Item1;
	 
