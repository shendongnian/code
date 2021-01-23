    [OutputCache(Duration = 300)]
    [ChildActionOnly]
    public ActionResult ProductPartial(long productId)
    {
        Product product = AProductProvider.Instance.GetProduct(productId);
        ControllerContext.ParentActionViewContext.ViewBag.PageTitle = product.Name;
    
        return View(product);
    }
