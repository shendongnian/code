    // Arrange
    // 1. Instantiate mocks
    var unitOfWork = MockRepository.GenerateMock<IUnitOfWork>();
    var repository = MockRepository.GenerateMock<IGenericRepository<Department>>();
    // 2. Setup unit of work to return mocked repository
    unitOfWork.Stub(uow => uow.DepartmentRepository).Returns(repository);
    // 3. Setup expectations - note that we ignore Department argument
    repository.Expect(rep => rep.Insert(Arg<Department>.Is.Anything));
    unitOfWork.Expect(uow => uow.Save());
    var dep = new Department("test");
    var depService = new DepartmentService(unitOfWork);
    // Act
    depService.Insert(dep.Name);
    // Assert
    repository.VerifyAllExpectations();
    unitOfWork.VerifyAllExpectations();
