    public ActionResult Index(DateTime? From, DateTime? To)
    {
        List<Purchase> purchases = new List<Purchase();
        if (From != null && To != null)
        {
            purchases = db.StockPurchases.Where(x => x.Date >= From && x.Date <= To).ToList();
        }
        else
        {
            purchases = db.StockPurchases.ToList();
        }
        Return View(purchases.ToList());
    }
