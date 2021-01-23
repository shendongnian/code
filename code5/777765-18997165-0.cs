    public ActionResult Products(string categoryid)
    {
    List<catProducts> lst = bindProducts(categoryid);
    return View(lst);
    }   
    public JsonResult Productsview(string categoryid)
    {
    //write your logic
    var Data = new { ok = true, catid = categoryid};
    return  Json(Data, JsonRequestBehavior.AllowGet);
    }
