    var result = resTable.Rows.Select(r => new {r, res = string.Concat(r[HeaderCol].ToString().Trim(),dot,r[FooterCol].ToString().Trim(),dot,r[TypeCol].ToString().Trim())})
         .Where(r => Map.ContainsKey(r.res))
         .GroupBy(r => r.res)
              .ToDictionary(g => g.Key,
    		      g => g.GroupBy(r => DateTime.FromOADate((double)r.r[DateCol]))
    			        .ToDictionary(c => c.Key,
    							c => c.Select(r => new ResultObj(DateTime.FromOADate((double)r.r[ResultDateCol]), new Decimal((double)r.r[PriceCol])))
    								.ToList()));
