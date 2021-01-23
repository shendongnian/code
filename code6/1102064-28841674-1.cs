	// arrange
	string applicationValue = "MyConnectionString";
	var mockApplication = new Mock<HttpApplicationStateBase>();
	mockApplication.SetupGet(s => s["TheConnectionString"]).Returns(applicationValue);
	var request = new Mock<HttpRequestBase>();
	var context = new Mock<HttpContextBase>();
	request.SetupGet(x => x.Headers).Returns(new WebHeaderCollection { { "X-Requested-With", "XMLHttpRequest" } });
	context.SetupGet(ctx => ctx.Request).Returns(request.Object);
	context.SetupGet(ctx => ctx.Application).Returns(mockApplication.Object);
	var sut = new AccSerController();
	sut.ControllerContext = new ControllerContext(context.Object, new RouteData(), sut);
	CInt cInt = new CInt();
	cIn.Iss = "Other";
	cIn.Tick = "BK";
	
    // act
    var actual = accController.GetClist(cIn);
	// assert
	Assert.IsNotNull(actual);
