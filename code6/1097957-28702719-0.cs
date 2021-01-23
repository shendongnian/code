    public ActionResult Index(string searchString, string datepicker, string datepicker2)
    {
        var transactions = db.transactions.Include(t => t.Client).Include(t => t.DocumentType).Include(t => t.MovementType1);
        if (!String.IsNullOrEmpty(searchString))
        {
            //Get your dates here...
            var fromDate = Convert.ToDateTime(datepicker);
            var toDate = Convert.ToDateTime(datepicker2);
            transactions = transactions.Where(s => s.Client.Name.Contains(searchString) && 
                                              s.Date >= fromDate && s.Date < toDate);     
        }
        return View(transaccions.ToList());
    }
