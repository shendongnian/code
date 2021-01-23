    public ActionResult MoniDetails()
    {
        MoniModel mim = new MoniModel();
        MoniGridModel migm = new MoniGridModel();
        mim.CategoryId = 1;
        mim.CategoryName = "a";
        mim.ProductId = 1;
        mim.ProductName = "b";
        migm.AddDetail(mim);
        return View(migm);
    }
