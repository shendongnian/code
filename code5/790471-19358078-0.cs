    [HttpPost]
    public ActionResult MyAction(MyModel model)
    {
        if (!ModelState.IsValid) 
        {
            return View();
        }
        // magic: handle model
    }
