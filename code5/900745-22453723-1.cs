    [TestClass]
    public class EmployeeUnitTest
    {
        Mock<IUnitOfWork> _unitOfWork;
        IEmployeeRepository _employeeRepository;
        //This will be called before each test
        [TestInitialize]
        public void SetUp()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _employeeRepository = new EmployeeRepository();
        }
        [TestMethod]
        public void GetById_ShouldCallUnitOfWork()
        {
            //Arrange
            const int Id = 1;
            _unitOfWork.Setup(x => x.GetById<Employee>(It.IsAny<int>())).Verifiable();
            //Act
            _employeeRepository.GetById(Id);
            //Assert
            _unitOfWork.Verify(x => x.GetById<Employee>(Id), Times.Once());
        }
        [TestMethod]
        public void GetById_ShouldRetrunEmployee()
        {
            //Arrange
            const int Id = 1;
            var expectedEmp = new Employee { Id = Id, Name= "Emp"};
            _unitOfWork.Setup(x => x.GetById<Employee>(It.IsAny<int>())).Returns(expectedEmp) ;
            //Act
            var employee = _employeeRepository.GetById(Id);
            //Assert
            Assert.AreEqual(expectedEmp, employee);
        }
    }
}
