    [HttpPost]
    public ActionResult AddToList(object newObject) 
    {
        var list = Sesssion["List"] as List<Object>;
        if (list == null) { 
            list = new List<Object>();
            Session["List"] = list;
        }
        list.add(newObject);
        return View(list); // Assuming the view is a strong-typed view with List<Object> as model
    }
