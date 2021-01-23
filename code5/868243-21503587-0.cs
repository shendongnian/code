    public ActionResult Invoices()
    {
        try{
            invoiceClass invoice = getInvoice();
            //do stuff with invoice
        }catch (exception e){
            return RedirectToAction("Index");
        }
    }
    
    public invoiceClass getInvoice()
    {
        invoiceClass invoice = new invoiceClass();
        try
        {
            // Do stuff
        }
        catch(exception e)
        {
            index(); //<--the action result
        }
        return invoice;
    }
