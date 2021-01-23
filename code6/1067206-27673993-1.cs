    public void fillPctReturns()
    {
        stockPctReturns = new List<decimal>();
        marketPctReturns = new List<decimal>();
        // Declare amexResult here so it is accessible outside the using block
        List<StockMarketCompare> amexResult;
        using (DailyGlobalDataTableAdapter dailyGlobalAdapter = new DailyGlobalDataTableAdapter())
        using (DailyAmexDataTableAdapter dailyAmexAdapter = new DailyAmexDataTableAdapter())
        using (DailyGlobalDataTable dailyGlobalTable = new DailyGlobalDataTable())
        using (DailyAmexDataDataTable dailyAmexTable = new DailyAmexDataDataTable())
        {
            dailyAmexAdapter.Fill(dailyAmexTable);
            dailyGlobalAdapter.Fill(dailyGlobalTable);
            var amexQuery = from c in dailyGlobalTable.AsEnumerable()
                            where c.Date >= DateTime.Now.Subtract(TimeSpan.FromDays(60))
                            orderby c.Date descending
                            join d in dailyAmexTable.AsEnumerable() on c.Date equals d.Date
                            select new StockMarketCompare { stockClose = d.AdjustedClose, marketClose = c.AdjustedClose };
            amexResult = amexQuery.ToList();
         }
         // perform calculations here and save to stockPctReturns and marketPctReturns
    }
