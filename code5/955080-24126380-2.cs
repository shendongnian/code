    public ActionResult Survey()
    {
        return View(new Survey());
    }
    
    [HttpPost]
    public ActionResult Survey(Survey model)
    {
        //do something worthwhile with the model, like validation, etc. etc.
    
        //even setting the model's boolean doesn't help the rendering.
        model.LikesCandy = true;
        //clear model state so that the change on the line above is applied
        ModelState.Clear();
    
        //then return to the page
        return View(model);
    }
