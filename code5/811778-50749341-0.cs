    [HttpPost]
    public ActionResult RedirectToImages(int id)
    {
        return RedirectToAction("Index", "ProductImageManeger", new  { id = id });
    }
    [HttpGet]
    public ViewResult Index(int id)
    {
        return View(_db.ProductImages.Where(rs => rs.ProductId == id).ToList());
    }
