    [HttpPost]
    public ActionResult AddItem(ParentViewModel item)
    {
       ViewModel newItem = item.NewItem;// <-- bound using the name to properties mapping
    }
