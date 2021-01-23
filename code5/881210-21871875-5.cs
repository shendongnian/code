         var currencycodes = new List<SomeCodes>
         {
            new CurrencyCodes(){Id = 1, Code = "IND", Description = "India"},
            new CurrencyCodes(){Id = 2, Code = "USA", Description = "UnitedStates"},
            new CurrencyCodes(){Id = 3, Code = "UAE", Description = "ArabEmirates"}
         };
         var mockEfContext = new Mock<EFDbContext>();
         var mockCacheManager = new Mock<ICacheManager>();
         var mockSessionManager = new Mock<ISessionManager>();
         var mockAppSettings = new Mock<IApplicationSettings>();
         // Setups for relevant methods of the above here, e.g. to test a cache miss
         mockEfContext.SetupGet(x => x.SomeCodes)
            .Returns(currencycodes); // Canned currencies
         mockCacheManager.Setup(x => x.Get<IEnumerable<SomeCodes>>(It.IsAny<string>()))
            .Returns<IEnumerable<SomeCodes>>(null); // Cache miss
         // Act
         var service = new CodeService(mockEfContext.Object, mockCacheManager.Object,
            mockSessionManager.Object, mockAppSettings.Object);
         var codes = service.GetAllCodes();
         // Assert + Verify
         mockCacheManager.Verify(x => x.Get<IEnumerable<SomeCodes>>(
            It.IsAny<string>()), Times.Once, "Must always check cache first");
         mockEfContext.VerifyGet(x => x.SomeCodes,
            Times.Once, "Because of the simulated cache miss, must go to the Db");
         Assert.AreEqual(currencycodes.Count, codes.Count(), "Must return the codes as-is");
