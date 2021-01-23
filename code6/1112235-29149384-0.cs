    [ChildActionOnly]
    public ActionResult CategoryList()
    {
        var categories = new Webshop.DAL.ShopContext().Categories.ToList();
        return PartialView("_CategoryList", categories);
    }
