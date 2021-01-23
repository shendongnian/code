    [HttpPost]
    public ActionResult CreateProductFromAjaxForm(CreateProductModel model)
    {
        if (!ModelState.IsValid)
        {
            return Json("error", JsonRequestBehavior.AllowGet);
        }
       //add to database
        return Json(model, JsonRequestBehavior.AllowGet);
    } 
