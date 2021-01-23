    public ActionResult ReturnView()
    {
        //populate model
        IEnumerable<CartItemsByStore>model =db.GetItemsByStore();
        return PartialView("Store",model)
    }
    
    public ActionResult DeleteCartItem(int id)
    {
        //delete
       return RedirectToAction("ReturnView");
    }
