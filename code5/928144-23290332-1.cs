    [Fact]
    public void GetAllBusAcnt()
    {
        var mockMyDb = MockDBSetup.MockMyDb();
        //create a mock for the service, and setup the call for GetBusAcnts
        var serviceMock = new Mock<IBusAcntService>();
        var expectedBusAccounts = new List<BusIdxVm>(){ new BusIdxVm(), ...a few more...  };
        serviceMock.Setup(s => s.GetBusAcnts(mockMyDb.Object, ....other params...)).Returns(expectedBusAccounts);
        //Create the controller using both mocks
        var controller = new BusAcntController(serviceMock.Object, mockMyDb.Object);
        var controllerContextMock = new Mock<ControllerContext>();
        controllerContextMock.Setup(
          x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("admin")))
          ).Returns(true);
        controller.ControllerContext = controllerContextMock.Object;
    
        var viewResult = controller.Index() as ViewResult;
        var model = viewResult.Model as PagedBusIdxModel;
    
        Assert.NotNull(model);
        Assert.Equal(6, model.BusAcnts.ToList().Count());
        Assert.Equal("Company 2", model.BusAcnts.ToList()[1].CmpnyName);
    }
