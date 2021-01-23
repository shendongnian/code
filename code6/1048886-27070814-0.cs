    dbContext.BoxesInputs
	.Select(g => new
	{
		CategoryId = g.CategoryId,
		ColorId = g.ColorId,
		Weight = r.Weight
	})
	.Union(dbContext.BoxesOutputs
		.Select(g => new
		{
			CategoryId = g.CategoryId,
			ColorId = g.ColorId,
			Weight = r.Weight
		})
	)
	.GroupBy(c => new { c.CategoryId, c.ColorId })
	.Select(g => new
	{
		categoryId = g.Key.CategoryId,
		colorId = g.Key.ColorId,
		sumOfWeights = g.Sum(r => (decimal?)r.Weight) ?? 0,
	}).ToList();
