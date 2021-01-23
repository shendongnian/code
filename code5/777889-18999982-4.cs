        [Test]
        public void ShouldSucessfully_SaveNewDepartment()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepository = new Mock<IRepository<Department>>();
            Department newDept = new Department { CreatedOn = DateTime.Now, Status = true, DepartmentFullName = "DFN", DepartmentCode = "DC" };
            mockUnitOfWork.Setup(x => x.GetRepository<Department>()).Returns(mockRepository.Object);
            var sut = new DepartmentService(mockUnitOfWork.Object);
            // Act
            bool result = sut.SaveDepartment(newDept);
            // Assert 
            Assert.That(result, Is.True);
        }
       [Test]
        public void ShouldThrowExceptionWhenExceptionThrownInternally_SaveNewDepartment()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepository = new Mock<IRepository<Department>>();
            mockUnitOfWork.Setup(x => x.GetRepository<Department>()).Returns(mockRepository.Object);
            mockUnitOfWork.Setup(uow => uow.Save()).Throws<Exception>();
            var sut = new DepartmentService(mockUnitOfWork.Object);
            // Act
            TestDelegate action = () => sut.SaveDepartment(new Department());
            // Assert 
            Assert.Throws<Exception>(action);
        }
