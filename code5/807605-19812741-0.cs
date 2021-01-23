    var query = from r in generateData().AsEnumerable()
                group r by r.Field<string>("CustomerLocation") into g
                select new
                {
                    CustomerLocation = g.Key,
                    SumSubTotal = g.Sum(r => r.Field<int>("SubTotal")),
                    OrderCount = g.Count(),
                    SumCustomerDebt = 
                          g.GroupBy(r => r.Field<int>("CustomerID"))
                           .Sum(cg => cg.First().Field<int>("CustomerDebt"))
                };
