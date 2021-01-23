    var mockEfContext = new Mock<EFDbContext>();
    var mockCacheManager = new Mock<ICacheManager(); 
    var mockSessionManager = new Mock<ISessionManager>();
    var appSettings = new Mock<IApplicationSettings>();
    // Setups for relevant methods of the above here, e.g. to test a cache miss
    mockEfContext.SetupGet(x => x.SomeCodes)
          .Returns(currencycodes); // Canned currencies
    mockCacheManager.Setup(x => x.Get<IEnumerable<SomeCode>>(It.IsAny<ClassOfCacheKey>())
          .Returns(null); // Cache miss
    // Act
    var service = new CodeService(mockEfContext,Object, mockCacheManager.Object, 
        mockSessionManager.Object, mockAppSettings.Object);
    var codes = service.GetAllCodes();
    // Assert + Verify
    mockCacheManager.Verify(x => x.Get<IEnumerable<SomeCode>>(
               It.IsAny<ClassOfCacheKey>(), Times.Once, "Must always check cache first");
    mockEfContext.VerifyGet(x => x.SomeCodes,
               Times.Once, "Because of the simulated cache miss, must go to the Db");
    Assert.AreEqual(currencycodes.Count, codes.Count, "Must return the codes as-is");
    // etc
