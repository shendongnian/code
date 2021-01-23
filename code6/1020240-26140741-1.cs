    public JsonResult ProductDetailJSON(int id)
    {
        // ... lots of operations that include usage of ViewBag and a Model ...
        return Json(new {
                // ControllerContext - modify it so it accepts Id
                html = View("ProductDetail").Capture(ControllerContext),
                name = ""
                // ... more properties
            }, JsonRequestBehavior.AllowGet);
    }
