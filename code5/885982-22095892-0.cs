        public ActionResult GetStockHistory(string[] symbols, int maxRows = Int32.MaxValue)
        {
            IEnumerable<IEnumerable<StockRecord>> records;
            
            records = repository.StockRecords
                .Where(r => symbols.Contains(r.Symbol))
                .GroupBy(r => r.Symbol)
                .Select(g => g
                    .OrderByDescending(g2 => g2.RecordDate)
                    .Take(maxRows)
                    .OrderBy(g3 => g3.RecordDate));
            
            return Json(records, JsonRequestBehavior.AllowGet); 
        }
