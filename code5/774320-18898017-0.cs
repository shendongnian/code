    [TestMethod]
    public void GetRoomsTest()
    {
      var fake = Substitute.For<ICodeCamperUow>();
      
      // do something to adjust the fake here
      var controller = new LookupsController(fake);
      var result = controller. GetRooms().Any();
      Assert.IsTrue(result);
    }
