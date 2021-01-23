    private Mock<IUnitOfWork> mockUnitOfWork;
    private Mock<IRepository<Department>> mockRepository;
    private DepartmentService sut;
    [SetUp]
    public void SetUp()
    {
        mockUnitOfWork = new Mock<IUnitOfWork>();
        mockRepository = new Mock<IRepository<Department>>();
        mockUnitOfWork.Setup(x => x.GetRepository<Department>())
                      .Returns(mockRepository.Object);
        sut = new DepartmentService(mockUnitOfWork.Object);
    }
    // tests will be here
