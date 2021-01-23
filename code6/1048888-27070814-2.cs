    dbContext.BoxesInputs
	.Select(g => new TempClass
	{
		CategoryId = g.CategoryId,
		ColorId = g.ColorId,
		InputWeight = r.Weight,
		OutputWeight = 0,
	})
	.Union(dbContext.BoxesOutputs
		.Select(g => new TempClass
		{
			CategoryId = g.CategoryId,
			ColorId = g.ColorId,
			InputWeight = 0,
			OutputWeight = r.Weight
		})
	)
	.GroupBy(c => new { c.CategoryId, c.ColorId })
	.Select(g => new
	{
		categoryId = g.Key.CategoryId,
		colorId = g.Key.ColorId,
		sumOfInputWeights = g.Sum(r => r.InputWeight),
		sumOfOutputWeights = g.Sum(r => r.OutputWeight),
	}).ToList();
    public class TempClass
    {
		public int CategoryID { get; set; }
		public int ColorID { get; set; }
		public decimal InnerWeight { get; set; }
		public decimal OuterWeight { get; set; }
    }
