    public ActionResult MoniDetails()
    {
        MoniModel mim = new MoniModel();
        MoniGridModel migm = new MoniGridModel();
        mim.CategoryId = 1;
        mim.CategoryName = "a";
        mim.ProductId = 1;
        mim.ProductName = "b";
        var details = new List<MoniModel>();
        details.Add(mim);
        migm.MoniDetails = details;
        return View(migm);
    }
