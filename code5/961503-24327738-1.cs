    public ActionResult Index(DateTime? From, DateTime? To)
    {
        List<StockPurchase> purchases = new List<StockPurchase>();
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
