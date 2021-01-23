    [TestInitialize]
    public void Init()
    {
        this.mockUOW = new Mock<ISomeDependency>();
        this.mock2 = new Mock<IAnotherDependency>();
        this.mock3 = new Mock<IYetAnotherDependency>();
        // Do initial set-up on your mocks
        this.controllerToTest = new MyExampleController(this.mockUOW, this.mock2, this.mock3);
    }
