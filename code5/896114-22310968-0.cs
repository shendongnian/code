    [ChildActionOnly]
    public ActionResult MyAction(MyModel model)
    {
         var newList = model.MyList.Where(l => l.Id == myId).ToList();
         return PartialView("_MyPartial", newList);
    }
