    public ActionResult Details(int id)
    {
    var data = _Context.Products.Where(d => d.ProductId == id).First();
    
    if (data == null)
    {
    return HttpNotFound();
    }
    return View(data);
    }
