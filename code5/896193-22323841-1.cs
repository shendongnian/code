    private HomeController _homeController;
    private Mock<HttpSessionStateBase> _mockSession;
    private Mock<HttpRequestBase> _mockRequest;
    [SetUp]
    public void Setup()
    {
        _mockRequest = new Mock<HttpRequestBase>();
        _mockSession = new Mock<HttpSessionStateBase>();
        var mockHttpContext = new Mock<HttpContextBase>();
        var mockControllerContext = new Mock<ControllerContext>();
        mockHttpContext.Setup(c => c.Request).Returns(_mockRequest.Object);
        mockHttpContext.Setup(c => c.Session).Returns(_mockSession.Object);
        mockControllerContext.Setup(c => c.HttpContext).Returns(mockHttpContext.Object);
        _homeController = new HomeController();
        _homeController.ControllerContext = mockControllerContext.Object;
    }
