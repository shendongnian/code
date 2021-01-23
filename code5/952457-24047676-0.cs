    return quotes
    	.GroupBy(q => q.Symbol)
    	.SelectMany(g => g.Buffer(2, 1).Select(b => new PriceChange {
    		Symbol = b[0].Symbol,
    		Change = (b[1].Price - b[0].Price) / b[0].Price
    	 })
    	);
