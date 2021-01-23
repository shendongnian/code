     public ActionResult Index()
      {     
              TransactionHistoryModel model = new TransactionHistoryModel();      
               model.StatusList = GetStatus();
                model.TypeOfChangeList = GetChangeTypeTransactions();
    OR
            ViewBag.statusasdID = GetStatus();
            ViewBag.TypeofasdID = GetChangeTypeTransactions();
               return View(model);
          }
