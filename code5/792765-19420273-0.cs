	context.Transaction
		   .Include("Security.Prices")
		   .Where(transaction =>
			  transaction.Security.Prices.Any(price => price.Date < transaction.Date))
		   .Select(t => new Transaction
		   {
			   // Only select prices before the given date
			   Prices = t.Prices.Where(price => price.Date < transaction.Date),
			   OtherProperty = t.OtherProperty,
			   // etc...
		   })
		   .ToList();
