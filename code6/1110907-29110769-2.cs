    [TestMethod]
    public void House_AddFrostedPaneWindowToLivingRoomFrontDoor_WindowExists()
    {
        var myHouse = new House();
        myHouse.Rooms.Add(new Room { Name = "Living Room" });
        myHouse.Rooms["Living Room"].Doors.Add(new Door { Name = "Front" });
        myHouse.Rooms["Living Room"].Doors["Front"].Windows.Add(new Window { Name = "Frosted Four Pane" });
        var window = myHouse.Rooms["Living Room"].Doors["Front"].Windows["Frosted Four Pane"];
        Assert.IsNotNull(window);
    }
