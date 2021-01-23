    [HttpPost]
    public ActionResult ActionName(ModelName model, string Action)
    {
    if(Action.Equals("button1")
    {
    }
    if(Action.Equals("buttons")
    {
    //write your code to add items in list
    model.itemList.Add(newitem);
    }
    return RedirectToAction("ActionName",model);
    }
