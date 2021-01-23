    [HttpPost]
    public ActionResult InvoiceType(clsInvoiceType Model, string Stade)
    {
        this.ModelState.Remove("Stade");  // or .Clear() to remove all keys
        Model.Stade = Stade== "1" ? true : false;
        return PartialView(Model);
    }
