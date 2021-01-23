    [Test]
        public void ShouldThrowExceptionWhenDepartmentCodeIsNull_SaveNewDepartment()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            Department newDept = new Department
                                     {
                                         CreatedOn = DateTime.Now, 
                                         Status = true, DepartmentFullName = "DFN", 
                                         DepartmentCode = null
                                     };
            var sut = new DepartmentService(mockUnitOfWork.Object);
            // Act
            TestDelegate action = () => sut.SaveDepartment(newDept);
            // Assert 
            Assert.Throws<ArgumentException>(action);
        }
