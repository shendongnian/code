    protected Context()
    {
        MapperConfig.RegisterMappings();
    }
    [TestInitialize]
    protected void Setup()
    {
        var settingsRepository = new Repository<Setting>();
        settingsRepository.Add(new Setting { Key = "LOGLEVEL", Value = "DEBUG" });
        // Mock the IUnitOfWork.
        var uow = new Mock<IUnitOfWork>();
        uow.SetupGet(x => x.LogRepository).Returns(new Repository<Log>());
        uow.SetupGet(x => x.SettingRepository).Returns(settingsRepository);
        unitOfWork = uow.Object;
    }
