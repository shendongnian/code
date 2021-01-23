    [Test]
    public void Should_add_any_valid_employees_and_save_them()
    {
       //arrange
       var validator = new Mock<IEmployeeValidator>();
       validator.Setup(v => v.Validate(It.IsAny<Employee>())).Returns(true);
    
       // ... setup the context and the dbset
    
       var service = new MyService(validator.Object, mockContext.Object)
    
       var newData = new List<EmployeeDto>
          {
             new EmployeeDto{Id = 1},
             new EmployeeDto{Id = 2}
          }
    
       // act
       service.AddEmployees(newData);
    
       // assert
       mockContext.Verify(c => c.SaveChanges(), Times.Once());
       Assert.True(fakeDbSet.Count == newData.Count);
       CollectionAssert.AreEquivalent( newData.Select(e=>e.Id), mockData.Select(e=>e.Id));
    }
    
    [Test]
    public void Should_not_add_any_invalid_employees()
    {
       //arrange
       var validator = new Mock<IEmployeeValidator>();
       validator.Setup(v => v.Validate(It.IsAny<Employee>())).Returns(false);
    
       // ... setup the context and the dbset
    
       var service = new MyService(validator.Object, mockContext.Object)
    
       var newData = new List<EmployeeDto>
          {
             new EmployeeDto{Id = 1},
             new EmployeeDto{Id = 2}
          }
    
       // act
       service.AddEmployees(newData);
    
       // assert
       mockContext.Verify(c => c.SaveChanges(), Times.Never());
       Assert.True(fakeDbSet.Count == 0);
       CollectionAssert.IsEmpty( mockData );
    }
