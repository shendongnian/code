    public ActionResult Invoices()
    {
        try
        {
            invoiceClass invoice = getInvoice();
            //do stuff with invoice
            return Json(...);
        }
        catch
        {
            //Catch the exception at the top level
            return RedirectToAction("Index");
        }
    }
    
    public invoiceClass getInvoice()
    {
        invoiceClass invoice = new invoiceClass();
        // Do stuff; possibly throw exception if something goes wrong
        return invoice;
    }
