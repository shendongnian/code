    public void GetEmployeeUsername_Using_EmployeeClass()
    {
        var mockCMS = new Mock<ICMS_Repository>(MockBehavior.Strict);
        Employee newEmp = new Employee();
        newEmp.User_Name = "testName";
        mockCMS.Setup(repos => repos.FindEmployeeByUsername(It.IsAny<Employee>())).Returns(newEmp);
                    
        var service = new EmployeeService(mockCMS.Object);
        var createResult = service.GetEmployeeByUserName(newEmp);
        Assert.AreEqual(newEmp, createResult);
    }
