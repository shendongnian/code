    [OutputCache(Duration=0, VaryByParam="none")]
    [HttpPost]
    public ActionResult InvoiceType(clsInvoiceType Model, string Stade)
    {
        Model.Stade = Stade== "1" ? true : false;
        return PartialView(Model);
    }
