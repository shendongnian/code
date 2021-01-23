    List<Record> records = new List<Record>() 
	{
		new Record() { ViewId = 1, FilterType = "COMPANY", FilterValue = "ONS" },
		new Record() { ViewId = 1, FilterType = "COMPANY", FilterValue = "TEK"}, 
		new Record() { ViewId = 1, FilterType = "CUSTOMERID", FilterValue = "178822"}, 
		new Record() { ViewId = 1, FilterType = "MANAGERID", FilterValue = "05082807"}, 
		new Record() { ViewId = 1, FilterType = "SITEID", FilterValue = "00525" },
		new Record() { ViewId = 1, FilterType = "SITEID", FilterValue = "00720" }
	};
	var xxx = records.GroupBy(rec => rec.FilterType)
					 .Select(g =>
								 new { g.Key, 
									   Values = g.Select(r => r.FilterValue)
											     .Aggregate(new StringBuilder(), 
                                                            (acc, val) => acc.Append(",").Append(val)).ToString().TrimStart(',') 
							         }
                            );
