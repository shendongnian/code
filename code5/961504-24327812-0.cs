    // GET: /Popular/
    public ActionResult Index(DateTime? From, DateTime? To)
    {
        if (From != null && To != null)
        {
            return View(db.StockPurchases.Where(x => x.Date >= From && x.Date <= To).ToList());
        }
        else
        {
            return return View(db.StockPurchases.ToList());
        }
    }
