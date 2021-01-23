    public JsonResult Create(string ProdCatID, string Flag)
    {
        if (ModelState.IsValid)
        {
            if (flag == "dropdown")
            {
                //your code goes here.
            }
            if (flag == "button")
            {
                //your code goes here/
            }
        }
        var model = db.GetProductCategories.where(id=>id.ProductCategoryID==ProductCatID).ToList();
        return Json(model, JsonRequestBehavior.AllowGet);
    }
