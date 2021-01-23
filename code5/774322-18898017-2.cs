    [TestMethod]
    public void GetRoomsTest()
    {
      // UOW we need to use
      var fakeUOW = Substitute.For<ICodeCamperUow>();
      
      // setting up room repository so that it returns a collection of one room
      var fakeRooms = Substitute.For<IRepository<Room>>();
      var fakeRoomsQueryable = new[]{new Room()}.AsQueryable();
      fakeRooms.GetAll<Room>().Returns(fakeRoomsQueryable);
      // connect UOW with room repository
      fakeUOW.Rooms.Returns(fakeRooms);
      
      var controller = new LookupsController(fakeUOW);
      var result = controller.GetRooms().Any();
      Assert.IsTrue(result);
    }
