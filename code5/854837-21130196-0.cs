    [HttpPost]
    public ActionResult Preview(string Docs)
    {
        TempData["Docs"] = Docs;
         return RedirectToAction("UnInvoicedPreview");
    }
