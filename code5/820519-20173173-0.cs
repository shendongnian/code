    public ActionResult Display(int data)
    {
        // retrun the query .ToList() to ensure that the data is fully enumerated
        // before the pipeline calls the view
        var query = dbentity.tbl_product.FirstOrDefault(c => c.ProductId == data);
        // You had ClickUC, rather than ClickUS
        return PartialView("ClicksUS", query);
    }
