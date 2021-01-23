    public ActionResult getTransactionTotals(int itemID)
        {
            DBEntities db = new DBEntities();
    
            var query = (from trans in db.Transactions
                        // Linq query removed for brevity
                            into selection
                            select new TransactionAmount
                            {
                                name = selection.Key,
                                amount = selection.Select(t => t.TransactionId).Distinct().Count()
                            }).ToList();
            var data = query.ToDictionary(k => k.name, v => v.amount);
    
            return Json(data ,JsonRequestBehavior.AllowGet);
        }
