    [HttpPost]
    public ActionResult Edit(RoomViewModel rvm)
    {
        string name = rvm.Name;
        int id = rvm.ID;
        UpdateRoomName(id, name);
    }
