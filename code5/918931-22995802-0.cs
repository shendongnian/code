    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(FormContext form)
    {
        if(ModelState.IsValid)
        {
            Contract hc = new Contract();
            hc.CreatedDate = DateTime.Now;
            hc.CreatedBy = "TestSubject";
            db.Contracts.Add(hc);
            db.SaveChanges();
            return RedirectToAction("CreateMain", new { contractID = hc.ContractID });
        }
        return View();
    }
    public ActionResult CreateMain(int contractID)
    {
        return View(new Main() {
                            ContractID = contractID
                        });
    }
