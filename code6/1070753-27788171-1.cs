        [TestInitialize]
        public void Setup()
        {
            userService = new Mock<IUserService>();
            //... setup userService
            someOtherServiceMock = new Mock<ISomeOtherService>();
            //... setup someOtherService
            mocks = new Dictionary<Type, Mock>()
            {
                { typeof(IUserService), userService },
                { typeof(ISomeOtherService), someOtherServiceMock}
            };
            myFactory= new Mock<IMyFactory>();
            SetupCreateFoo<MyFirstClass>(myFactory);
            SetupCreateFoo<MySecondClass>(myFactory);
            // ... etc
            finderService = new FinderService(userService.Object, myFactory.Object);
            
        }
