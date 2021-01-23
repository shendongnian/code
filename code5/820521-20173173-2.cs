    public ActionResult Display(int data)
    {
        // using First() would have caused you an error in the view if not found
        // still not perfect below, but a step closer 
        var query = dbentity.tbl_product.FirstOrDefault(c => c.ProductId == data);
        // You had ClicksUC, rather than ClicksUS
        return PartialView("ClicksUS", query);
    }
