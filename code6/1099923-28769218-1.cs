    public ActionResult YourAction(YourModel Model)
    {
        var selections = Model.myItemList
            .Where(m => m.IsSelected)
            .ToList();
       //do what you want with those selections
    }
