    public ActionResult Edit(int? id = null) 
    {
        Room r = UnitOfWork.GetContext().Rooms
            .Where(i => i.ID == id.Value).FirstOrDefault();
        RoomViewModel rvm = new RoomViewModel();
        rvm.ID = r.ID;
        rvm.Name = rvm.Name;
        if (needToBindChildren) rvm.ChildItems = r.ChildItems;
        return View(rvm);
    }
