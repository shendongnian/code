    public ActionResult Create(Transactions transactions)
            {
                using (var unit = new UnitOfWork())
                {
                    if (ModelState.IsValid)
                    {
                        transactions.TrnDate = DateTime.Now;
                        var manager = unit.UserManager;
                        var currentUser = manager.FindById(User.Identity.GetUserId());
                        transactions.Agent = currentUser.SalesAgent;
                        unit.TransactionRepository.Insert(transactions);
                        unit.Save();
                        return RedirectToAction("Index");
                    }
                    ViewBag.StatusId = new SelectList(unit.LoanStatusRepository.Get(), "StatusId", "Status");
                    return View(new CreateTrnVM());
                }
