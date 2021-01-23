    var q = ctx.tblPrices.OrderByDescending(x => x.Cost)
                    .ToList()
                    .GroupBy(x => x.ItemID)
                    .Select(g => new {g, count = g.Count()})
                    .SelectMany(t => t.g.Select(b => b).Zip(Enumerable.Range(1, t.count), (j, i) => new {j.WebPrice, j.PriceID, j.ItemID}));
