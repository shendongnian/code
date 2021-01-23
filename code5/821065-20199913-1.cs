    public ActionResult ActionName()
    {
        var result = new List<BunkViewModel>();
        var rooms = RoomHelper.FindAllRooms();
        var bunks = BunkHelper.GetAllBunks();
        
        foreach(var bunk in bunks)
        {
            var bunkViewModel = BunkViewModel.Map(bunk);
            var room = rooms.FirstorDefault(r=>room.RoomId == bunk.RoomId);
            bunkViewModel.RoomId = room.RoomId; //No need to set if you already have this id in bunk
            bunkViewModel.RoomName = room.RoomName;
            result.Add(bunkViewModel);
        }
        return View(result.);
    }
