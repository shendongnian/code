    var x = from t1 in context.OTAXs
                        group t1.Code by new { t1.Code } into g
                        where g.Count()<=1
                        join txs in context.OTAXs on g.Key.Code equals txs.Code
                        select new TaxModel { taxCode = txs.Code, taxName = txs.Code, description = txs.Code, taxRate = txs.Rate.Value };                        
