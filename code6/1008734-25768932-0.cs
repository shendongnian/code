    var query = from t in db.CURRENT_JCT_TRANSACTION
                group t by t.Cost_Code into g
                orderby g.Key ascending
                select new
                {
                    CostCode = g.Key,
                    Total = g.Sum(t => t.Amount),
                    Categories = 
                        from t in g
                        group t by t.Category into cg
                        select new
                        {
                            CostCode = g.Key,
                            Category = cg.Key,
                            Amount = cg.Sum(t => t.Amount)
                        }
                };
