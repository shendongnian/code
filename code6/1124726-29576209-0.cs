    public ActionResult Index()
    {
        var transactions = new List<Portal.Models.TransactionModels>();
        transactions.Add(new Portal.Models.TransactionModels{
            id = "1",
            statusId = 4
        })
        transactions.Add(new Portal.Models.TransactionModels{
            id = "2",
            statusId = 3
        })
        return View(transactions);
    }
