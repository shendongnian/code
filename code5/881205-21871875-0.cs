    var mockEfContext = new Mock<EFDbContext>();
    var mockCacheManager = new Mock<ICacheManager(); 
    var mockSessionManager = new Mock<ISessionManager>();
    var appSettings = new Mock<IApplicationSettings>();
    // Setups for relevant methods of the above here
    var service = new CodeService(mockEfContext,Object, mockCacheManager.Object, 
        mockSessionManager.Object, mockAppSettings.Object);
    var code = service.GetAllCodes();
    // Verify
    mockCacheManager.Verify(x => x.Get<IEnumerable<SomeCode>>(
               It.IsAny<ClassOfCacheKey>(), Times.Once);
    // etc
