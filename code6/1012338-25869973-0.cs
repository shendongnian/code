    using (CrystalReportsTestEntities db = new CrystalReportsTestEntities())
    {
        List<Stock> stocks = db.Stocks.Where(item => item.StockSalePrice > 5).ToList();
        report.SetDataSource(stocks);
    }
