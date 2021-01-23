    var resultList = FabricCost.Concat(AccessoryCost)
                               .Concat(FOBRevenue)
                               .Concat(StockCost)
                               .Concat(StockRevenue)
                               .Concat(FixedCost)
                               .GroupBy(x => x.Year)
                               .Select(g => new SalesSummaryDAO ()
                                {
                                  Year = g.Key,
                                  Cost = g.Sum(x => x.Cost)
                                })
                               .ToList();
