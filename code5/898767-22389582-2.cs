    public ActionResult AnAction()
    {
        var model = new CartProduct();
        model.MyItems = new DropDownListModel<ItemType>
        {
            Items = _yourListOfItems,
            SelectedItem = _yourSelectedItem
        };
        
        return View(model);
    }
