    foreach (var enumVal in Enum.GetValues(Minute))
	{
		if (reservations.All(r => r.Minute != enumVal))
		{
			return enumVal;
		}
	}
	
	return reservations.Where(r => r.Hour == Hour.eleven)
					   .GroupBy(r => r.Minute)
					   .OrderBy(m => m.Count())
    				   .Select(rr => rr.Key)
					   .Last();
