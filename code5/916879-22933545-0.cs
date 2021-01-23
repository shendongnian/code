	var opvCount =
		opv
			.OrderProductVariants
			.Count
			.ToString();
	
	return
		orders
			.Where(o => o.PaymentStatus == PaymentStatus.Paid)
			.GroupBy(g => g.CreatedOnUtc.Date.ToString("yyyyMMdd"))
			.Select(s => new
			{
				Date = s.Key,
				Count = s.Count()
			})
			.Select(x =>
				new GCOrdersModelg(x.Date, g.Count.ToString(), opvCount));
