    [SetUp]
        public void SetUp()
        {
            addCount = 0;
            IEnumerable<Platform> platformList = new List<Platform>(){
                new Platform() { Id = 1, Name = "Unknown"},
                new Platform() { Id =2, Name = "Amazon"},
                new Platform() { Id = 3, Name = "Prime Pantry"}
            };
            var platformData = platformList.AsQueryable();
            var mockPlatformSet = new Mock<DbSet<Platform>>();
            mockPlatformSet.As<IQueryable<Platform>>().Setup(m => m.Provider).Returns(platformData.Provider);
            mockPlatformSet.As<IQueryable<Platform>>().Setup(m => m.Expression).Returns(platformData.Expression);
            mockPlatformSet.As<IQueryable<Platform>>().Setup(m => m.ElementType).Returns(platformData.ElementType);
            mockPlatformSet.As<IQueryable<Platform>>().Setup(m => m.GetEnumerator()).Returns(platformData.GetEnumerator());
            mockPlatformSet.Setup(m => m.Add(It.IsAny<Platform>())).Callback(() => addCount++);
            var mockContext = new Mock<ApplicationDbContext>(){ CallBase = true };
            mockContext.Setup(m => m.Platforms).Returns(mockPlatformSet.Object);
            mockContext.Setup(m => m.Platforms.Add(It.IsAny<Platform>()));
            mockContext.Setup(m => m.Platforms.Add(It.IsAny<Platform>())).Callback(() => addCount++);
            mockContext.Setup(m => m.Set<Platform>()).Returns(mockPlatformSet.Object);
            mockContext.As<IUnitOfWork>().CallBase = false;
            
            unitOfWork = new UnitOfWork(mockContext.Object);
            platformRepo = new PlatformRepository(mockContext.Object);
            controller = new PlatformController(platformRepo, unitOfWork);
        }
